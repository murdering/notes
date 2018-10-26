# C#
## Basics
* decimal 不是基本类型
* bool和整数不能隐式转换
* `'a'` 是char类型, `“a”`是string类型
* object类型的两个目的：
   1. 用来绑定所有子类型对象，和反射
   2. 重写。其实现有`Equals()`, `ToString()`, `GetType()`.
* string
   1. `@` --》不会转义
   2. string 修改时, 是新建一个对象
   3. `$` --》C# 6新特性, 允许{}里放变量或者代码表达式
* Enum
   1. 枚举是用户定义的整数类型
   2. Enum.Parse返回的其实是一个对象
* 命名空间一般格式为CompanyName.ProjectName.SystemSection
* `Main()`方法
   1. 使用`static`修饰符
   2. 在任意类中
   3. 返回`int`或者`void`
* 预处理器指令
   1. 场景：划分版本，比如基本版和企业版
   2. 最好不用DEBUG，调试的时候用debug模式会失效
   3. `#warning`只是提示，`#error`会退出编译，不生成IL代码
   4. `#pragma`是抑制或者还原指定编译警告
* 编程准则
   1. `@`是使用关键字为标识符的方法，比如：`@abstract`
   2. C#常量最好不要全部是大写，很难阅读。还是Pascal
   3. 私有常常是下划线加小驼峰 `private int _subscribed`
## Class
* 属性
   1. .net 4.0后精简为 `public int Age {get; set;}`
   2. 初始值为 `public int Age {get; set;} = 50;`
* 方法
   1. C# 6 提供lambda给一个语句的方法 `public bool IsSquare(Rectangle rect) => rect.Height == rect.Width;`
   2. 参数可以带名字 `r.Move(x: 30, y: 40, width: 50)`
   3. 必须为可选参数提供默认值，并且可选参数应该是最后一个参数 
   4. 如果多个可选参数，可以传递任意可选参数，并且可以乱序 `TestMethod(1, opt3: 4);`
   5. `params`关键字是任意数量的参数。`AnyNumberOfArguments(1, 3, 4)`
   > ```C#
   > public void AnyNumberOfArguments(params int[] data){ 
   >      foreach(var x in data)
   >      {
   >          WriteLine(x);
   >      }
   > }
   > ```
 * 构造函数
   1. 如果只有一个带单个参数的构造函数，编译器不会创建默认构建函数。意思是说不会有没带参数的构造函数
   2. 私有构造函数使用场景：
      + 类只访问静态成员或属性
      + 单例模式。只能用静态方法来实例化。
   3. 构造函数初始化器。可以用来调用同一个类的另一个构造函数，或者积累的构造函数(用base，而不是this)
   > ```C#
   > public Car
   > {
   >     private string _description;
   >     private uint _wheels;
   >     public Car(string description, uint wheels){
   >         _description = description;
   >         _wheels = wheels;
   >     }
   >     public Car(string description) : this(description, 4)
   >     {
   >     }
   > }
   > ```
   4. 静态构造函数
      + 无参数
      + 只执行一次，通常在第一次调用类成员之前执行。
      + 没有修饰符，因为总是在类加载时调用
      + 只能访问类的静态成员
      + 和无参数的实例构造函数不冲突
