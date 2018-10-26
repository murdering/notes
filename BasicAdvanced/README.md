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
* 预处理器指令
> 1. 场景：划分版本，比如基本版和企业版
> 2. 最好不用DEBUG，调试的时候用debug模式会失效
> 3. #warning只是提示，#error会退出编译，不生成IL代码
> 4. #pragma是抑制或者还原指定编译警告
* 编程准则
> 1. @是使用关键字为标识符的方法，比如：@abstract
> 2. C#常量最好不要全部是大写，很难阅读。还是Pascal
> 3. 私有常常是下划线加小驼峰, private int _subscribed