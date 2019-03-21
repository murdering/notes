## 搭建Skywalking收集服务器环境
* [Skywalking 6.0环境搭建](https://www.jianshu.com/p/bb31c9cac5d0)
* [Skywalking Github](https://github.com/apache/incubator-skywalking)
* 不用集群的话，可以不用安装elastic search
* jdk 版本 >= 8
* 指定ip地址，不要用默认的
* webapp下的yml：listOfServers配置为正确的ip，不是WebUI会一直报错，并且找不到内容。

## SkyAPM-dotnet使用
* [.net core服务添加skywalking6探针](https://www.cnblogs.com/weiBlog/p/10427454.html)
> 1. 引入skywalking包
> 2. 添加一个skyapm.json的文件（从一个已有的服务中拷贝）到项目根目录
> 3. 修改skyapm.json中的服务名字(`config["SkyWalking:ServiceName"]`)和skywalking收集服务器接口地址(`config["SkyWalking:Transport:gRPC:Servers`，这个一个环境都是一样的)
* [SkyAPM-dotnet Github](https://github.com/SkyAPM/SkyAPM-dotnet)：但是步骤不够详细
* 环境变量不要"SKYWALKING__SERVICENAME"，在skyapm.json中会有名字，不然service中不会有记录
* 服务返回500就会有请求失败
![=](https://ww1.sinaimg.cn/large/007i4MEmgy1g0villshzej30n708wglz.jpg)

## 配置回调，并发送邮件
* [skywalking webhooks方法为post](https://my.oschina.net/u/3920392/blog/2998115)
* 配置在Collector服务器的alarm-settings.yml中
* 腾讯smtp服务器端口使用587
* [默认报警配置为以下(skywalking 6才引入的回调方式)](https://github.com/apache/incubator-skywalking/blob/master/docs/en/setup/backend/backend-alarm.md)
>1. Service average response time over 1s in last 3 minutes.
>2. Service success rate lower than 80% in last 2 minutes.
>3. Service 90% response time is lower than 1000ms in last 3 minutes.
>4. Service Instance average response time over 1s in last 2 minutes.
>5. Endpoint average response time over 1s in last 2 minutes.
## Notice
1. 重启了skywalking, 容器也需要重启才能重新监听。