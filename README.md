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

## 代码质量管理
* [sonarqube+sonar runner分析C#代码](https://www.cnblogs.com/luoqin520/p/6945304.html)
* [基于Win10极简SonarQube C#代码质量分析](https://www.cnblogs.com/CoderAyu/p/9416376.html)

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
* [mysql36条军规](https://github.com/murdering/notes/blob/master/Resources/mysql36%E6%9D%A1%E5%86%9B%E8%A7%84.pdf)

## Https
* [https原理通俗了解](https://www.cnblogs.com/zhangshitong/p/6478721.html)
* 一句话总结
> HTTPS要使客户端与服务器端的通信过程得到安全保证，必须使用的对称加密算法，但是协商对称加密算法的过程，需要使用非对称加密算法来保证安全，然而直接使用非对称加密的过程本身也不安全，会有中间人篡改公钥的可能性，所以客户端与服务器不直接使用公钥，而是使用数字证书签发机构颁发的证书来保证非对称加密过程本身的安全。这样通过这些机制协商出一个对称加密算法，就此双方使用该算法进行加密解密。从而解决了客户端与服务器端之间的通信安全问题。

## 设计模式的六大原则
* [设计模式的六大原则](https://www.cnblogs.com/fengyumeng/p/10463048.html)
> 1. 开闭原则：对扩展开放,对修改关闭，多使用抽象类和接口。
> 2. 里氏替换原则：基类可以被子类替换，使用抽象类继承,不使用具体类继承。
> 3. 依赖倒转原则：要依赖于抽象,不要依赖于具体，针对接口编程,不针对实现编程。
> 4. 接口隔离原则：使用多个隔离的接口,比使用单个接口好，建立最小的接口。
> 5. 迪米特法则：一个软件实体应当尽可能少地与其他实体发生相互作用，通过中间类建立联系。
> 6. 合成复用原则：尽量使用合成/聚合,而不是使用继承。
* [23种设计模式全解析](https://www.cnblogs.com/susanws/p/5510229.html)

## Git
* [Git最佳实践](http://www.cnblogs.com/wish123/p/9785101.html)

## 微服务
* [微服务架构的理论基础 - 康威定律](https://yq.aliyun.com/articles/8611)

## 开源协议
* [开源协议选择](https://coderxing.gitbooks.io/architecture-evolution/chapter1/di-yi-zhang-ff1a-zhun-bei-qi-cheng/12-guan-yu-kai-yuan/123-kai-yuan-xie-yi-de-xuan-ze.html)

## Markdown
* [Markdown基本语法](https://www.jianshu.com/p/191d1e21f7ed)

