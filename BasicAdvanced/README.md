# C#
### Basics
* decimal 不是基本类型
* bool和整数不能隐式转换
* 'a' 是char类型, “a”是string类型
* object类型的两个目的：
> 1. 用来绑定所有子类型对象，和反射
> 2. 重写。其实现有Equals(), ToString(), GetType().
* string
> 1. @ --》不会转义
> 2. string 修改时, 是新建一个对象
> 3. $ --》C# 6新特性, 允许{}里放变量或者代码表达式
* Enum
> 1. 枚举是用户定义的整数类型
> 2. Enum.Parse返回的其实是一个对象
* 命名空间一般格式为CompanyName.ProjectName.SystemSection
* Main()方法
> 1. 使用static修饰符
> 2. 在任意类中
> 3. 返回int或者void
