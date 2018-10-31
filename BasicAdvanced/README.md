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
## ClassAndType
* 属性
   1. .net 4.0后精简为 `public int Age {get; set;}`
   2. 初始值为 `public int Age {get; set;} = 50;`
* 方法
   1. C# 6 提供lambda给一个语句的方法 `public bool IsSquare(Rectangle rect) => rect.Height == rect.Width;`
   2. 参数可以带名字 `r.Move(x: 30, y: 40, width: 50)`
   3. 必须为可选参数提供默认值，并且可选参数应该是最后一个参数 
   4. 如果多个可选参数，可以传递任意可选参数，并且可以乱序 `TestMethod(1, opt3: 4);`
   5. `params`关键字是任意数量的参数。`AnyNumberOfArguments(1, 3, 4)`
      ```C#
      public void AnyNumberOfArguments(params int[] data){ 
           foreach(var x in data)
           {
               WriteLine(x);
           }
      }
      ```
* 构造函数
   1. 如果只有一个带单个参数的构造函数，编译器不会创建默认构建函数。意思是说不会有没带参数的构造函数
   2. 私有构造函数使用场景：
      + 类只访问静态成员或属性
      + 单例模式。只能用静态方法来实例化。
   3. 构造函数初始化器。可以用来调用同一个类的另一个构造函数，或者积累的构造函数(用base，而不是this)
      ```C#
      public Car
      {
          private string _description;
          private uint _wheels;
          public Car(string description, uint wheels){
              _description = description;
              _wheels = wheels;
          }
          public Car(string description) : this(description, 4)
          {
          }
      }
      ```
   4. 静态构造函数
      + 无参数
      + 只执行一次，通常在第一次调用类成员之前执行。
      + 没有修饰符，因为总是在类加载时调用
      + 只能访问类的静态成员
      + 和无参数的实例构造函数不冲突
  
* 只读成员
    1. 带有`readonly`修饰符的字段只能在构造函数中分配值
    2. 作为类成员时，需要用`static`修饰符
    3. C# 6 自动实现的只读属性 `public string Id { get;} = Guid.NewGuid().ToString()`
    4. readonly和const的区别：

    | const | readonly |
    | ------ | ------ |
    | 默认静态的 | 需要用static修饰符 |
    | 必须在声明时给与值 |  可以在构造函数中赋值 |
    | 不能继承 | 能继承 |
    | 静态成员 | 实例成员 |

* 匿名类型 
    1. 编译器会伪造一个类名，只有编译器使用它。对新对象使用反射，不会得到一致的结果。
       ```C#
       var captiain = new {
           FirstName = "Leo",
           LastName = "Dai"
       }
       ```
* 结构体
    1. 值类型
    2. 不支持继承
    3. 默认构造函数会初始化成员为其默认值
    4. 默认构造函数总是隐式给出，即使提供了其他参数的构造函数
    5. 自定义构造函数里必须给所有成员初始值
    6. C# 6才可以实现默认构造函数，之前是不行的
    7. 如果使用属性, 对象就必须用new
    8. 和类的区别：

    | 结构体 | 类 |
    | ------ | ------ |
    | 值类型 | 引用类型 |
    | 可以不用new新建，new只是调用构造函数来初始化所有字段 |  必须用new来分配堆内存 |
    | 不能继承 | 能继承 |
    | 默认构造函数总是给出 | 如过声明了构造函数，就不会给出默认构造函数 |
* 可空类型
    1. `int? x = null`
    2. `int y = x ?? -1` 如果x为空给-1，否则提取x的值
* 枚举
    1. 值类型
    2. 默认情况下，类型是int。可以变为其他整数类型(byte, short, int, long)
       ```C#
       public enum Color : short
       {
           Red = 1,
           Green = 2,
           Blue = 3
       }
       ```
*  部分类 `partial class`
    1. 可以在一个部分类中声明一个方法，而在另一个部分类中实现这个方法
    2. 部分方法不能使用 访问修饰符
       ```C#
       public partial class PartialClass
       {
           public void MethodOne()
           {
               PartialFunction();
           }
   
           partial void PartialFunction();
       }
       ```
*  扩展方法
    1. 继承就是给对象添加功能的好方法，扩展方法就是给对象添加一功能的另一个选项，在不能继承时也可以使用这个选项
    2. 扩展方法是静态的，是类的一部分
    3. 使用**this**关键字和**第一个参数**来扩展字符串
    4. LINQ利用了许多扩展方法
       ```C#
       public static class StringExtension
       {
           public static int GetWordCount(this string s) => s.split().Length;
       }
       ```
*  Object类
    1. 其实所有类型都最终派生自System.Object
    2. `ToString()` : 对象的字符串表示
    3. `GetHashCode()` : Get HashCode
    4. `Equals()`, `ReferenceEquals()`
    5. `Finalize()` : 类似C++的析构函数，在对象被垃圾回收的时候调用。Object中的此方法实际什么都没做，会被GC忽略，如果对象有为托管的引用，就一般需要重写`Finalize()`
    6. `GetType()` ： 反射，得到对象的信息
    7. `MemberwiseClone()` : 浅拷贝
