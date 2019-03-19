## 监听服务
1. 新建一个单独的服务作为监听服务
2. 引入`AspNetCore.HealthChecks.UI`和`AspNetCore.HealthChecks.Uris`两个包（注：必须是.net core 2.2以上，这是新引入的功能）
3. 在`startup.cs`中启用HealthCheck
4. 在`appsetting.json`中配置监听服务接口(一个简单的get接口)和不健康时的回调函数
![1](https://ww1.sinaimg.cn/large/007i4MEmgy1g1837qmsb6j30ua0hx0we.jpg)
5. 访问健康检查UI
![2](https://ww1.sinaimg.cn/large/007i4MEmgy1g1839oa3fyj30xe0l6n09.jpg)

## 被监听服务
1. 创建一个空接口，以测试服务是否可抵达
![3](https://ww1.sinaimg.cn/large/007i4MEmgy1g173g0dyeyj30kf06974r.jpg)
2. 在以上监听服务`appsetting.json`的`HealthChecks`节点中添加一个新的节点

## 通知服务
1. 监听端口为`6070`
2. 在`notification`服务`appsetting.json`中配置邮件基本信息
![4](https://ww1.sinaimg.cn/large/007i4MEmgy1g17y9mqhxqj30ls065q3v.jpg)
3. 收到邮件
![5](https://ww1.sinaimg.cn/large/007i4MEmgy1g183btaihqj30cd042q2x.jpg)

## Reference
1. [Github: AspNetCore.Diagnostics.HealthChecks](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks)
2. [自定义检查项，输出，筛选，状态码](https://www.cnblogs.com/xxred/p/10322752.html)
3. [使用Uri检查](https://www.hanselman.com/blog/HowToSetUpASPNETCore22HealthChecksWithBeatPulsesAspNetCoreDiagnosticsHealthChecks.aspx)
4. [微软官方微服务运行状况监视介绍](https://docs.microsoft.com/zh-cn/dotnet/standard/microservices-architecture/implement-resilient-applications/monitor-app-health)