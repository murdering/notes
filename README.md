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
* [『浅入浅出』MySQL 和 InnoDB(一篇足以)](https://draveness.me/mysql-innodb)
* [事务的4种隔离级别](https://blog.csdn.net/qq_33290787/article/details/51924963)
> 1. RAED UNCOMMITED：使用查询语句不会加锁，可能会读到未提交的行（Dirty Read）；
> 2. READ COMMITED：只对记录加记录锁，而不会在记录之间加间隙锁，所以允许新的记录插入到被锁定记录的附近，所以再多次使用查询语句时，可能得到不同的结果（Non-Repeatable Read）；
> 3. REPEATABLE READ：多次读取同一范围的数据会返回第一次查询的快照，不会返回不同的数据行，但是可能发生幻读（Phantom Read）；
> 4. SERIALIZABLE：InnoDB 隐式地将全部的查询语句加上共享锁，解决了幻读的问题；
* [【MySQL】悲观锁&乐观锁](https://www.cnblogs.com/zhiqian-ali/p/6200874.html)
> 乐观锁和悲观锁其实都是并发控制的机制
> 1. 乐观锁是一种思想，它其实并不是一种真正的『锁』，它会先尝试对资源进行修改，在写回时判断资源是否进行了改变，如果没有发生改变就会写回，否则就会进行重试，在整个的执行过程中其实都没有对数据库进行加锁；
> 2. 悲观锁就是一种真正的锁了，它会在获取资源前对资源进行加锁，确保同一时刻只有有限的线程能够访问该资源，其他想要尝试获取资源的操作都会进入等待状态，直到该线程完成了对资源的操作并且释放了锁后，其他线程才能重新操作资源；
> 3. 共享锁（读锁）：允许事务对一条行数据进行读取；
> 4. 互斥锁（写锁）：允许事务对一条行数据进行删除或更新；

## Markdown
* [Markdown基本语法](https://www.jianshu.com/p/191d1e21f7ed)

