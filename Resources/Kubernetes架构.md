## Kubernetes架构

#### Agenda
- Kubernetes总体架构
- Pod
- Service
- NodePort vs LoadBalancer vs Ingress

#### Kubernetes总体架构

- **总体架构**
![1.png](https://i.loli.net/2020/05/18/4Yeghfkwp1APUs8.png)
![2.png](https://i.loli.net/2020/05/18/6LbDdvlJXF5PUH1.png)

- **k8s集群**
![3.png](https://i.loli.net/2020/05/18/LeCKwPZlvpmyx2V.png)

- **Master节点是K8s集群大脑，它由如下组件构成：**
![4.png](https://i.loli.net/2020/05/18/F8L6Eum7qRYotn9.png)

1. **Etcd：** 它是K8s的集中状态存储，所有的集群状态数据，例如节点，Pods，发布，配置等等，最终都存储在Etcd中。Etcd是一个分布式KV数据库，采用Raft分布式一致性算法。Etcd高可用部署一般需要至少三个节点。Etcd集群可以独立部署，也可以和Master节点住在一起。
2. **API server：** 它是K8s集群的接口和通讯总线。用户通过kubectl，dashboard或者sdk等方式操作K8s，背后都通过API server和集群进行交互。集群内的其它组件，例如Kubelet/Kube-Proxy/Scheduler/Controller-Manager等，都通过API server和集群进行交互。API server可以认为是Etcd的一个代理Proxy，它是唯一能够访问操作Etcd数据库的组件，其它组件，都必须通过API server间接操作Etcd。API server不仅接受其它组件的API请求，它还是集群的事件总线，其它组件可以订阅在API server上，当有新事件发生时候，API server会将相关事件通知到感兴趣的组件。
3. **Scheduler：** 它是K8s集群负责调度决策的组件。Scheduler掌握当前的集群资源使用情况，当有新的应用发布请求被提交到K8s集群，它负责决策相应的Pods应该分布到哪些空闲节点上去。K8s中的调度决策算法是可以扩展的。
4. **Controller Manager：** 它是保证集群状态最终一致的组件。它通过API server监控集群状态，确保实际状态和预期状态最终一致，如果一个应用要求发布十个Pods，Controller Manager保证这个应用最终启动十个Pods，如果中间有Pods挂了，Controller Manager会负责协调重启Pods，如果Pods启多了，Controller Manager会负责协调关闭多余Pods。也即是说，K8s采用最终一致调度策略，它是集群自愈的背后实现机制。

- **Worker节点是K8s集群资源的提供者，它由如下组件构成：**
![5.png](https://i.loli.net/2020/05/18/UXPK4SObm6jCLTN.png)

1. **Kubelet:** 它是Worker节点资源的管理者，相当于一个Agent角色。它监听API server的事件，根据Master节点的指示启动或者关闭Pod等资源，也将本节点状态数据汇报给Master节点。如果说Master节点是K8s集群的大脑，那么Kubelet就是Worker节点的小脑。
2. **Container Runtime:** 它是节点容器资源的管理者，如果采用Docker容器，那么它就是Docker Engine。Kubelet并不直接管理节点的容器资源，它委托Container Runtime进行管理，比如启动或者关闭容器，收集容器状态等。Container Runtime在启动容器时，如果本地没有镜像缓存，则需要到Docker Registry(或Docker Hub)去拉取相应镜像，然后缓存本地。
3. **Kube-Proxy:** 它是管理K8s中的服务(Service)网络的组件。Pod在K8s中是ephemeral的概念，也就是不固定的，PodIP可能会变(包括预期和非预期的)。为了屏蔽PodIP的可能的变化，K8s中引入了Servie概念，它可以屏蔽应用的PodIP，并且在调用时进行负载均衡。Kube-Proxy是实现K8s服务(Service)网络的背后机制。另外，当需要把K8s中的服务(Service)暴露给外网时，也需要通过Kube-Proxy进行代理转发。

- **K8s关键组件的作用**
![6.png](https://i.loli.net/2020/05/18/ZYVTiKxP6oguSEb.png)

如果我们把Master节点和Worker节点集成起来，就构成上图所示的K8s集群。下面我们通过一个发布流程，展示上面介绍的这些组件是如何配合工作的。

1. 假设管理员要发布一个新应用，他通过Kubectl命令行工具将发布请求提交到API server，API server将请求存储到Etcd数据库中。
2. Scheduler通过API server监听到有新的应用发布请求，它通过调度算法决策，选择若干可发布的空闲节点，并将发布决策更新到API server。
3. 被选中的Worker节点上的Kubelet通过API server监听到有给自己的新发布任务，它根据任务指示在本地启动相应的Pods(间接通过Container Runtime启动容器)，并将任务执行成功情况报告给API server。
4. 所有Worker节点上Kube-Proxy通过API server监听到有新的发布，它获取应用的PodIP/ClusterIP/端口等相关数据，更新本地的iptables表规则，让本地的Pods可以通过iptables转发方式，访问到新发布应用的Pods。
5. Controller Manager通过API server，时刻监控新发应用的健康状况，保证实际状态和预期状态最终一致。

- **K8s网络分层**
![7.png](https://i.loli.net/2020/05/18/ZXDGLBQuAlgqct4.png)

#### Pod
- **Pod:** Pod相当于是K8s云平台中的虚拟机，它是K8s的基本调度单位。所谓Pod网络，就是能够保证K8s集群中的所有Pods(包括同一节点上的，也包括不同节点上的Pods)，逻辑上看起来都在同一个平面网络内，能够相互做IP寻址和通信的网络。

- **知识总结:** 
1. K8s的网络可以抽象成四层网络，第0层节点网络，第1层Pod网络，第2层Service网络，第3层外部接入网络。除了第0层，每一层都构建于上一层之上。
2. 一个节点内的Pod网络依赖于虚拟网桥和虚拟网卡等linux虚拟设备，保证同一节点上的Pod之间可以正常IP寻址和互通。一个Pod内容器共享该Pod的网络栈，这个网络栈由pause容器创建。
3. 不同节点间的Pod网络，可以采用路由方案实现，也可以采用覆盖网络方案。路由方案依赖于底层网络设备，但没有额外性能开销，覆盖网络方案不依赖于底层网络，但有额外封包解包开销。
4. CNI是一个Pod网络集成标准，简化K8s和不同Pod网络实现技术的集成。
![8.png](https://i.loli.net/2020/05/18/TPhXCVEYb7OKsIZ.png)

#### Service
- **Service:** 有了Pod网络，K8s集群内的所有Pods在逻辑上都可以看作在一个平面网络内，可以正常IP寻址和互通。但是Pod仅仅是K8s云平台中的虚拟机抽象，最终，我们需要在K8s集群中运行的是应用或者说服务(Service)，而一个Service背后一般由多个Pods组成集群，这时候就引入了服务发现(Service Discovery)和负载均衡(Load Balancing)等问题，这就是第2层Service网络要解决的问题。

- **解决的问题：**
1. **服务发现**：Account-Service提供统一的ClusterIP来解决服务发现问题，Client只需通过ClusterIP就可以访问Account-App的Pod集群，不需要关心集群中的具体Pod数量和PodIP，即使是PodIP发生变化也会被ClusterIP所屏蔽。注意，这里的ClusterIP实际是个虚拟IP，也称Virtual IP(VIP)。
2. **负载均衡**：Account-Service抽象层具有负载均衡的能力，支持以不同策略去访问Account-App集群中的不同Pod实例，以实现负载分摊和HA高可用。K8s中默认的负载均衡策略是RoundRobin，也可以定制其它复杂策略。

- **简化的服务注册发现流程：**
1. **首先**，在服务Pod实例发布时(可以对应K8s发布中的Kind: Deployment)，Kubelet会负责启动Pod实例，启动完成后，Kubelet会把服务的PodIP列表汇报注册到Master节点。
2. **其次**，通过服务Service的发布(对应K8s发布中的Kind: Service)，K8s会为服务分配ClusterIP，相关信息也记录在Master上。
3. **第三**，在服务发现阶段，Kube-Proxy会监听Master并发现服务ClusterIP和PodIP列表映射关系，并且修改本地的linux iptables转发规则，指示iptables在接收到目标为某个ClusterIP请求时，进行负载均衡并转发到对应的PodIP上。
4. **运行时**，当有消费者Pod需要访问某个目标服务实例的时候，它通过ClusterIP发起调用，这个ClusterIP会被本地iptables机制截获，然后通过负载均衡，转发到目标服务Pod实例上
![9.png](https://i.loli.net/2020/05/18/rF8eMo76gUcdwLa.png)

- **Service网络原理：**
![10.png](https://i.loli.net/2020/05/18/4f9IzuLnjXChHvF.png)

- **知识总结：**
1. K8s的Service网络构建于Pod网络之上，它主要目的是解决服务发现(Service Discovery)和负载均衡(Load Balancing)问题。
2. K8s通过一个ServiceName+ClusterIP统一屏蔽服务发现和负载均衡，底层技术是在DNS+Service Registry基础上发展演进出来。
3. K8s的服务发现和负载均衡是在客户端通过Kube-Proxy + iptables转发实现，它对应用无侵入，且不穿透Proxy，没有额外性能损耗。
4. K8s服务发现机制，可以认为是现代微服务发现机制和传统Linux内核机制的优雅结合。

#### NodePort vs LoadBalancer vs Ingress
##### NodePort
- **NodePort**: NodePort是K8s将内部服务对外暴露的基础，后面的**LoadBalancer底层有赖于NodePort**。

如果我们要将K8s内部的一个服务通过NodePort方式暴露出去，可以将服务发布(kind: Service)的type设定为NodePort，同时指定一个30000~32767范围内的端口。服务发布以后，K8s在每个Worker节点上都会开启这个监听端口。这个端口的背后是Kube-Proxy，当K8s外部有Client要访问K8s集群内的某个服务，它通过这个服务的NodePort端口发起调用，这个调用通过Kube-Proxy转发到内部的Servcie抽象层，然后再转发到目标Pod上。
![11.png](https://i.loli.net/2020/05/18/mFHD3qcTi2RsxnP.png)

##### LoadBalancer
- **LoadBalancer**: 服务的集群的负载均衡器。

假设我们有一套阿里云K8s环境，要将K8s内部的一个服务通过LoadBalancer方式暴露出去，可以将服务发布(Kind: Service)的type设定为LoadBalancer。服务发布后，阿里云K8s不仅会自动创建服务的NodePort端口转发，同时会自动帮我们申请一个SLB，有独立公网IP，并且阿里云K8s会帮我们自动把SLB映射到后台K8s集群的对应NodePort上。这样，通过SLB的公网IP，我们就可以访问到K8s内部服务，阿里云SLB负载均衡器会在背后做负载均衡。

值得一提的是，如果是在本地开发测试环境里头搭建的K8s，一般不支持Load Balancer也没必要，因为通过NodePort做测试访问就够了。但是在生产环境或者公有云上的K8s，例如GCP或者阿里云K8s，基本都支持自动创建Load Balancer。
![12.png](https://i.loli.net/2020/05/18/zbjJ1ye8vQYTBO9.png)

##### Ingress
- **Ingress**: k8s内部独立部署的反向代理服务，用来代理转发，功能和Nginx无本质差别，也就是内部网关，可使用Ocolet/Zuul/SpringCloudGateway/Kong/Envoy/Traefik等。

有了前面的NodePort + LoadBalancer，将K8s内部服务暴露到外网甚至公网的需求就已经实现了，那么为啥还要引入Ingress这样一个概念呢？它起什么作用？

我们知道在公有云(阿里云/AWS/GCP)上，公网LB+IP是需要花钱买的。我们回看上图的通过LoadBalancer(简称LB)暴露服务的方式，发现要暴露一个服务就需要购买一个独立的LB+IP，如果要暴露十个服务就需要购买十个LB+IP，显然，从成本考虑这是不划算也不可扩展的。那么，有没有办法只需购买一个(或者少量)的LB+IP，但是却可以按需暴露更多服务出去呢？答案其实不复杂，就是想办法在K8内部部署一个独立的反向代理服务，让它做代理转发。++谷歌给这个内部独立部署的反向代理服务起了一个奇怪的名字++，就叫**Ingress**。

**Ingress就是一个特殊的Service**，通过节点的**HostPort(80/443)**暴露出去，前置一般也有LB做负载均衡。Ingress转发到内部的其它服务，是通过集群内的Service抽象层/ClusterIP进行转发，最终转发到目标服务Pod上。Ingress的转发可以基于Path转发，也可以基于域名转发等方式，基本上你只需给它设置好转发路由表即可，**功能和Nginx无本质差别**。

所以，Ingress并不是什么神奇的东西，
+ **首先**，它本质上就是K8s集群中的一个比较特殊的Service(**发布Kind: Ingress**)。
+ **其次**，这个Service提供的功能主要就是7层反向代理(也可以提供安全认证，监控，限流和SSL证书等高级功能)，功能类似Nginx。
+ **第三**，这个Service对外暴露出去是通过HostPort(80/443)，可以和上面LoadBalancer对接起来。有了这个Ingress Service，我们可以做到只需购买一个LB+IP，就可以通过Ingress将内部多个(甚至全部)服务暴露出去，Ingress会帮忙做代理转发。

++那么哪些软件可以做这个Ingress？传统的Nginx/Haproxy可以，现代的微服务网关Zuul/SpringCloudGateway/Kong/Envoy/Traefik等等都可以++。当然，谷歌别出心裁给这个东东起名叫Ingress，它还是做了一些包装，以简化对Ingress的操作。如果你理解了原理，那么完全可以用Zuul或者SpringCloudGateway，或者自己定制开发一个反向代理，来替代这个Ingress。部署的时候以普通Service部署，将type设定为LoadBalancer即可。
![13.png](https://i.loli.net/2020/05/18/uX6oRpysD59TjSQ.png)

- **知识总结**：
1. NodePort是K8s内部服务对外暴露的基础，LoadBalancer底层有赖于NodePort。NodePort背后是Kube-Proxy，Kube-Proxy是沟通Service网络、Pod网络和节点网络的桥梁。
2. 将K8s服务通过NodePort对外暴露是以集群方式暴露的，每个节点上都会暴露相应的NodePort，通过LoadBalancer可以实现负载均衡访问。公有云(如阿里云/AWS/GCP)提供的K8s，都支持自动部署LB，且提供公网可访问IP，LB背后对接NodePort。
3. Ingress扮演的角色是对K8s内部服务进行集中反向代理，通过Ingress，我们可以同时对外暴露K8s内部的多个服务，但是只需要购买1个(或者少量)LB。Ingress本质也是一种K8s的特殊Service，它也通过HostPort(80/443)对外暴露。
4. 通过Kubectl Proxy或者Port Forward，可以在本地环境快速调试访问K8s中的服务或Pod。
5. K8s的Service发布主要有3种type，type=ClusterIP，表示仅内部可访问服务，type=NodePort，表示通过NodePort对外暴露服务，type=LoadBalancer，表示通过LoadBalancer对外暴露服务(底层对接NodePort，一般公有云才支持)。

- **Kubernetes网络三部分浓缩总结**：
![14.png](https://i.loli.net/2020/05/18/m28vZ9hX36EVupw.png)

#### References(非常感谢波波老师的分享🤗):
1. [架构师波波 - 如何理解Kubernetes架构?](https://blog.csdn.net/yang75108/article/details/100215486)
2. [架构师波波 - Kubernetes网络三部曲之一～Pod网络](https://blog.csdn.net/yang75108/article/details/101101384)
3. [架构师波波 - Kubernetes网络三部曲之一～Service网络](https://blog.csdn.net/yang75108/article/details/101267444)
4. [架构师波波 - Kubernetes网络三部曲之三 ~ NodePort vs LoadBalancer vs Ingress](https://blog.csdn.net/yang75108/article/details/101268208)
5. [架构师波波 - 构建微服务技术中台，SpringCloud和Kubernetes该如何选型？](https://blog.csdn.net/yang75108/article/details/99706510)
