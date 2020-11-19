# Notes

## .Net Core
* [用ASP.NET Core 2.0 建立规范的 REST API](http://www.cnblogs.com/cgzl/p/9010978.html)
* [理解POCO](https://kb.cnblogs.com/page/89750/)(就是和POJO一样，纯get/set class)
    * 为POJO增加了持久化的方法（Insert、Update、Delete……）之后，POJO就变成了PO。
    * 为POJO增加了数据绑定功能之后，POJO就变成了View Object，即UI Model。
    * 为POJO增加业务逻辑的方法（比如单据审核、转帐……）之后，POJO就变成了Domain Model。
    * POJO还可以当作DTO使用。
* [全面理解 ASP.NET Core 依赖注入](https://www.cnblogs.com/jesse2013/p/di-in-aspnetcore.html)
* AOP
    * [C#的AOP框架](https://www.cnblogs.com/kiba/p/9920691.html)
    * [C# 中使用面向切面编程（AOP）中实践代码整洁](https://www.cnblogs.com/chenug/p/9848852.html)
* [C# 8.0 新特性](https://www.cnblogs.com/Rwing/p/building-c-8-0.html)
* [C# 9.0和.Net5.0新特性](https://www.cnblogs.com/powertoolsteam/p/dotnet5.html)

## Database
* [MySQL、MongoDB、Redis 数据库之间的区别](https://blog.csdn.net/CatStarXcode/article/details/79513425?utm_source=blogxgwz1)
* [『浅入浅出』MySQL 和 InnoDB(一篇足矣)](https://draveness.me/mysql-innodb)
* [事务的4种隔离级别](https://blog.csdn.net/qq_33290787/article/details/51924963)
> 1. RAED UNCOMMITED：使用查询语句不会加锁，可能会读到未提交的行（Dirty Read）；
> 2. READ COMMITED：只对记录加记录锁，而不会在记录之间加间隙锁，所以允许新的记录插入到被锁定记录的附近，所以再多次使用查询语句时，可能得到不同的结果（Non-Repeatable Read）；
> 3. REPEATABLE READ：多次读取同一范围的数据会返回第一次查询的快照，不会返回不同的数据行，但是可能发生幻读（Phantom Read）；
> 4. SERIALIZABLE：InnoDB 隐式地将全部的查询语句加上共享锁，解决了幻读的问题；对于同一个数据来说，在同一个时间段内，只能有一个会话可以访问，包括select和dml，通过执行事务串行执行；
* [【MySQL】悲观锁&乐观锁](https://www.cnblogs.com/zhiqian-ali/p/6200874.html)
> 乐观锁和悲观锁其实都是并发控制的机制
> 1. 乐观锁是一种思想，它其实并不是一种真正的『锁』，它会先尝试对资源进行修改，在写回时判断资源是否进行了改变，如果没有发生改变就会写回，否则就会进行重试，在整个的执行过程中其实都没有对数据库进行加锁；
> 2. 悲观锁就是一种真正的锁了，它会在获取资源前对资源进行加锁，确保同一时刻只有有限的线程能够访问该资源，其他想要尝试获取资源的操作都会进入等待状态，直到该线程完成了对资源的操作并且释放了锁后，其他线程才能重新操作资源；
> 3. 共享锁（读锁）：允许事务对一条行数据进行读取；
> 4. 互斥锁（写锁）：允许事务对一条行数据进行删除或更新；
* [Mysql30条军规](https://github.com/murdering/notes/blob/master/Resources/Mysql%e5%86%9b%e8%a7%84.md)

## Kubernetes
* [Kubernetes架构](https://github.com/murdering/notes/blob/master/Resources/Kubernetes%E6%9E%B6%E6%9E%84.md)

## Https
* [https原理通俗了解](https://www.cnblogs.com/zhangshitong/p/6478721.html)
* 一句话总结
> HTTPS要使客户端与服务器端的通信过程得到安全保证，必须使用的对称加密算法，但是协商对称加密算法的过程，需要使用非对称加密算法来保证安全，然而直接使用非对称加密的过程本身也不安全，会有中间人篡改公钥的可能性，所以客户端与服务器不直接使用公钥，而是使用数字证书签发机构颁发的证书来保证非对称加密过程本身的安全。这样通过这些机制协商出一个对称加密算法，就此双方使用该算法进行加密解密。从而解决了客户端与服务器端之间的通信安全问题。

## GraphQL
* [30分钟理解GraphQL核心概念](https://segmentfault.com/a/1190000014131950?utm_source=tag-newest)
* [RPC vs REST vs GraphQL](https://segmentfault.com/a/1190000013961872)
* [Asp.Net Core Samples](https://github.com/murdering/notes/tree/master/GraphQL)
> 如果是`Management API`，这类API的特点如下：
> * 关注于对象与资源
> * 会有多种不同的客户端
> * 需要良好的可发现性和文档
>
> 这种情景使用`REST + JSON API`可能会更好。
>
> 如果是`Command or Action API`，这类API的特点如下：
> * 面向动作或者指令
> * 仅需要简单的交互
>
> 这种情况使用`RPC`就足够了。
> 
> 如果是`Internal Micro Services API`，这类API的特点如下：
> * 消息密集型
> * 对系统性能有较高要求
>
> 这种情景仍然建议使用`RPC`。
>
> 如果是`Micro Services API`，这类API的特点如下：
> * 消息密集型
> * 期望系统开销较低
>
> 这种情景使用`RPC`或者`REST`均可。
>
> 如果是`Data or Mobile API`，这类API的特点是：
> * 数据类型是具有图状的特点
> * 希望对于高延迟场景可以有更好的优化
>
> 这种场景无疑`GraphQL`是最好的选择。

## 设计模式的六大原则(S·O·L·I·D)
* [设计模式的六大原则](https://www.cnblogs.com/fengyumeng/p/10463048.html)
> 1. 开闭原则：对扩展开放,对修改关闭，多使用抽象类和接口。
> 2. 里氏替换原则：基类可以被子类替换，使用抽象类继承,不使用具体类继承。
> 3. 依赖倒转原则：要依赖于抽象,不要依赖于具体，针对接口编程,不针对实现编程。
> 4. 接口隔离原则：使用多个隔离的接口,比使用单个接口好，建立最小的接口。
> 5. 迪米特法则：一个软件实体应当尽可能少地与其他实体发生相互作用，通过中间类建立联系。
> 6. 合成复用原则：尽量使用合成/聚合,而不是使用继承。

> S：SRP, Single Responsibility Principle, 单一责任原则  
> O：OCP, Open Closed Principle, 开发封闭原则  
> L: LSP, Liskov Substitution Principle, 里氏替换原则  
> I：ISP, Interface Segregation Principle, 接口分离原则  
> D: DIP, Dependency Inversion Principle, 依赖倒置原则  
* [程序员该有的艺术气质—SOLID原则](https://www.cnblogs.com/lanxuezaipiao/archive/2013/06/09/3128665.html)
* [让姑姑不再划拳 码农也要有原则 ： SOLID via C#](https://www.cnblogs.com/xfuture/p/4169459.html)
* [23种设计模式全解析](https://www.cnblogs.com/susanws/p/5510229.html)

## 贫血模型 VS 充血模型
[贫血模型 VS 充血模型比较](https://www.cnblogs.com/longshiyVip/p/5205451.html)
> 贫血模型：是指领域对象里只有get和set方法，或者包含少量的CRUD方法，所有的业务逻辑都不包含在内而是放在Business Logic层。  
> 充血模型：层次结构和上面的差不多，不过大多业务逻辑和持久化放在Domain Object里面，Business Logic（业务逻辑层）只是简单封装部分业务逻辑以及控制事务、权限等。



## Git
* [Git最佳实践](http://www.cnblogs.com/wish123/p/9785101.html)

## 微服务
* [微服务架构的理论基础 - 康威定律](https://yq.aliyun.com/articles/8611)
> 通俗的说法就是：组织形式等同系统设计。
> 1. 组织沟通方式会通过系统设计表达出来。
> 2. 时间再多一件事情也不可能做的完美，但总有时间做完一件事情。
> 3. 线型系统和线型组织架构间有潜在的异质同态特性。更直白的说，你想要什么样的系统，就搭建什么样的团队。
> 4. 大的系统组织总是比小系统更倾向于分解。
* [分布式开放消息系统(RocketMQ)的原理与实践](https://www.cnblogs.com/HigginCui/p/9900148.html)
* [一张图秒懂微服务网络架构(高可用)](https://www.cnblogs.com/yuesf/p/11831234.html)

## 服务监控
* [.Net Core 服务健康检查](https://github.com/murdering/notes/tree/master/AspNetCore.HealthChecks.WithUriAndUI.Samples)
* [Skywalking](https://github.com/murdering/notes/blob/master/Resources/Skywalking.md)

## 代码质量管理
* [sonarqube+sonar runner分析C#代码](https://www.cnblogs.com/luoqin520/p/6945304.html)
* [基于Win10极简SonarQube C#代码质量分析](https://www.cnblogs.com/CoderAyu/p/9416376.html)

## 开源协议
* [开源协议选择](https://coderxing.gitbooks.io/architecture-evolution/chapter1/di-yi-zhang-ff1a-zhun-bei-qi-cheng/12-guan-yu-kai-yuan/123-kai-yuan-xie-yi-de-xuan-ze.html)

## Markdown
* [Markdown基本语法](https://www.jianshu.com/p/191d1e21f7ed)

