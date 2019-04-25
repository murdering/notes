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
## Inheritance
* 一句话形容多态：通过继承实现的不同对象调用相同的方法，表现出不同的行为，称之为多态
* 虚方法 `virtual`
    1. 基类中声明为`virtual`，就可以在任何派生类中重写该方法，用`override`
    2. 如果只是一行，C# 6中`virtual`可以用于lambda表达式
    3. C#中，函数默认情况下不是虚拟的，但可以显式的声明为`virtual`(构造函数除外)。Java中所有函数都是虚拟的。
    4. 如果签名相同的方法在基类和派生类中进行声明，但是没有用`virtual`和`override`，派生类会隐藏基类方法。而且子类应该使用new关键字来隐藏基类方法。
    5. 密封方法的一个场景是：表明这个方法终止继承。
* `public`,`protected`和`private`是逻辑访问修饰符。`internal`是一个物理访问修饰符，其边界是一个程序集。
* [抽象类和接口的相同点和区别](https://www.cnblogs.com/chunhui212/p/5892273.html)
* `is`和`as`不会抛出exception
## 托管和非托管的资源
* 值类型
    1. 栈实际是向下填充的，即由高内存地址向低内存地址填充
    2. 栈是先进后出
* 引用类型
    1. 堆是向上分配
    2. 对象其实分配了堆和栈的，栈是分配了对象堆的地址。如果实例化了，就可以在堆中找到。
* 垃圾回收
    1. 托管堆其实分为4部分：第0代，第1代，第2代和大对象堆
        1. 第0代：新创建的对象会驻留在这个地方。小但是快。
        2. 第1代：经过了一个垃圾回收执行后，第0代就会进入第1代。
        3. 第2代：再经过一个或者更多垃圾回收执行后，第1代酒会进去第2代。
        4. 大对象堆：用于处理较大对象（大于85000个字节）。不执行压缩过程。和第2代相似。
        > 当第0代分配完，没有容量时，就会自动执行垃圾回收。
* 处理非托管资源
    1. C#中定义析构函数时，编译器发送给程序集的实际是Finalize()方法
    2. C#析构函数的问题是它的不确定行。C++销毁对象时，立即执行析构函数。但是由于C#垃圾回收器的方式，无法确定析构函数什么时候执行。（因为销毁是由垃圾回收器执行的）
    3. `IDisposable.Dispose()`的实现是显式的释放非托管资源，提供精确的释放
    4. `using`的一个用法：非托管资源对象在超出作用域时，自动调用`Dispose()`方法。会`try/catch/finally` 等价的IL代码。
        ```C#
        using (var theInstance = new ResourceGobbler())
        {
            // do your processing
        }
        ```
## 泛型
* 优点
    1. 性能。`ArrayList`类是存储对象（引用类型），在`Add()`方法时是把一个对象作为参数，如果是值类型就有装箱操作。泛型`List<T>`T就定义了类型，就不会有装箱拆箱操作。
    2. 类型安全。`ArrayList`类其实可以添加任意类型，如果`foreach`迭代操作，就可能出现类型转换错误。泛型`List<T>`最开始就定义了类型，如果添加了不同的类型，在编译的时候就会报错。
    3. 命名约定。
        1. 泛型类型用字母`T`作为前缀
        2. 没有特殊要求，泛型类型允许用任意类型替代，且只是用了一个泛型类型，就用`T`作为泛型类型的名称
            ```C#
            public class List<T> {}
            public class LinkedList<T> {}
            ```
        3. 如果泛型类型有特定要求，或者使用了两个或者多个泛型类型，就给描述性的名称
            ```C#
            public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
            public delegate TOutput Converter<TInput, TOutput>(TInput from);
            public class SortedList<TKey, TValue> {}
            ```
* 泛型类
    1. 默认值
        1. 因为泛型类型可能为值类型或者引用类型，不能把null赋予值类型，所以泛型的默认值用`default`关键字，将null赋予引用类型，0赋予值类型。
    2. 约束
        1. `where` 关键字实现约束。
           ```C#
           public class DocumentManager<TDocument> where TDocument: IDcoument
           {
               //Implementation
           }
           ```
        2. 泛型还可以有多个约束`public class MyClass<T> where T: IFoo, new (){ //Implementation }` (`new()`这个约束是约束T必须有一个构造函数)
    3. 继承
        1. 派生类可以是泛型类或非泛型类
    4. 静态成员
        1. 静态成员只能在一个实例中共享。
           ```C#
           public class StaticDemo<T>
           {
               public static int x;
           }

           StaticDemo<string>.x = 4;
           StaticDemo<int>.x = 5;
           WriteLine(StaticDemo<string>.x);
           // 4
           ```
* 泛型接口的抗变与协边
    1.  协变：将子对象到父对象的转换。泛型接口中用`out`关键字标注，意味着返回类型只能是`T`。.net中参数是协变的。
    2.  抗变：将父对象到子对象的转换。泛型接口中用`in`关键字标注，意味着只能把泛型类型`T`用作其方法输入。
    3.  [C#的抗变与协变](http://blog.sina.com.cn/s/blog_8edc71930101xd9m.html)
* 泛型方法
    1. 泛型方法可以再非泛型类中定义
    2. 泛型方法可以像非泛型方法一样调用
       ```C#
       //泛型方法调用
       int i = 4;
       int j = 5;
       Swap<int>(ref i, ref j);
       //非泛型方法调用
       int i = 4;
       int j = 5;
       Swap(ref i, ref j);
       ```
    3. 泛型方法也可以用`where`字句来限制，定义约束。
       ```C#
       public static decimal Accumulate<TAccount>(IEnumerable<TAccount> source) where TAccount: IAccount
       {
           // Implementation
       }
       ```
    4. 带委托的泛型。
       ```C#
       //定义
       public static T2 Accumulate<T1, T2>(IEnumberable<T1> source, Func<T1, T2, T2> action)
       {
           // Implementation
           T2 sum = default(T2);
           foreach(var account in source)
           {
               sum = action(account, sum);
           }
           return sum;
       }
       //调用
       decimal amount = Algorithm.Accumulate<Account, decimal>(accounts, (item, sum) => sum += item.Balance);
       ```
    5. **方法是在编译期间定义的，而不是运行期间。**
* [C#之Action和Func的用法](https://www.cnblogs.com/LipeiNet/p/4694225.html)

## 数组
* 数组是引用类型
* 锯齿数组
  ```C#
  int[][] jagged = new int[3][];
  jagged[0] = new int[2] {1, 2};
  jagged[1] = new int[6] {3, 4, 5, 6, 7, 8};
  jagged[2] = new int[3] {9, 10, 11};
  ```
* `Clone()`是创建浅表副本，值类型会赋值所有的值；引用类型不复制元素，只复制引用。
* `Copy()`也是创建浅表副本。与`Clone()`的区别是：`Clone()`是创建一个新的数组，`Copy`是传入一个阶数相同且有足够元素的已有数组。
* [`IComparable<T>`和`IComparer<T>`的区别](https://www.cnblogs.com/leemano/p/4926637.html)

  | `IComparable` | `IComparer` |
  | ------ | ------ |
  | 用`CompareTo()` 比较 | 用`Compare()` 比较|
  | class实现`IComparable`接口，class内部实现`CompareTo()`方法 |  一个独立的class来实现`IComparer`接口，并实现`Compare()`方法 |
  | 调用比较方法不同 `Array.Sort(persons);` | `Array.Sort(persons, new PersonComparer(PersonTypeEnum.FirstName));` |
  | 如果有新的成员比较，需要修改原类 | 一个独立类，不需要修改原类，可以在此独立类中扩展 |
* `foreach`语句(以下是其实现的方式)
  ```C#
  // foreach语句
  foreach(var p in persons)
  {
      WriteLine(p);
  }
  // 生成的IL代码
  IEnumerator<Person> enumerator = persons.GetEnumerator();
  while(enumerator.MoveNext())
  {
      Person p = enumerator.Current;
      WriteLine(p);
  }
  ```
* `yield`语句
    * 集合迭代返回`yield return`。就是把迭代的每次`return`都返回回来，而不是只一次。
    * `IEnumerator<T>`是`GetEnumerator()`使用的返回接口。其他自定义的方法使用`IEnumerable<T>`接口
    * 实例
      ```C#
      public class HelloCollection
      {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "hello";
            yield return "world!";
        }
      }
      // 自定义方法
      public IEnumerable<string> Reverse()
      {
        for (int i = names.Length - 1; i >= 0; i--)
        {
            yield return names[i];
        }
      }
      // hello worl调用
      var helloCollection = new HelloCollection();

      foreach (var item in helloCollection)
      {
         WriteLine(item);
      }
      ```
## 运算符和类型强制转换
* `checked`和`unchecked`
    * `checked`会做溢出检查，如果溢出就抛出`OverflowException`。
    * `unchecked`不会做溢出检查，如果溢出就会，溢出的位就会丢弃，不会抛异常。
    * `unchecked`是默认行为。只有需要在有`checked`标记的大段代码中执行不检查一部分代码，才需要显式的用`unchecked`关键字。
    * `checked`会影响性能。
* `nameof`运算符是C#6新引入。改运算符接收一个符号，属性或方法，并返回名称。
* 可空类型
    * 使用关键字`?`类型声明是，例如`int?`，编译器会解析它，以使用泛型类型`Nullable<int>`。
    * 在比较可空类型是，只要一个参数是`null`，比较结果就是false。
    ```C#
    int? a = null;
    int? b = -5;
    if(a >= b)
    {
        WriteLine("a >= b");
    }
    else
    {
        WriteLine("a < b");
    }
    // 总是执行else语句
    ```
* `??`合并运算符
    * 如果第一个操作数不是`null`，整个表达式就等于第一个操作数的值；
    * 如果第一个操作数是`null`，整个表达式就等于第一个操作数的值；
* 空值传播运算符，C# 6的一个杰出新功能
    * 使用空值传播运算符来访问FirstName属性(`p.FirstName`)，当`p`为空时，返回`null`，而不执行表达式右侧。
      ```C#
      public void ShowPerson(person p)
      {
          string firstName = p?.FirstName;
      }
      ```
    * 访问数组的第一元素，如果是`null`，空合并运算符返回`x1`的值。
      ```C#
      int x1 = arr?[0] ?? 0;
      ```
* 类型转换
    * 只能从较小的整数类型隐式转换为较大的整数类型
    * 可空类型不能隐式转换为非可空类型
    * 显式转换有丢失数据的风险`int b = (int)a;`
    * 显式转换也有限制，在值类型转换时只能在数字，`char`类型和`enum`类型之间转换。不能直接把布尔型转换为其他类型，也不能把别的类型转换为布尔型。
* 比较对象的相等性
    * `ReferenceEquals()`用于比较引用，是个静态方法，传入两个引用对象。
    * `Equals()`用于比较值，其实每个类型都有这个虚方法，可以重写它。
    * `==`是个中间选项
* 运算符重载
  ```C#
  public static Vector operator +(Vector left, Vector right) => new Vector(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
  ```
* [C#中的Explicit和Implicit](https://www.cnblogs.com/lwqlun/p/8082405.html)
    * Implicit关键字用于声明隐式的用户定义类型转换运算符。
    * Explicit关键字声明必须通过转换来调用的用户定义的类型转换运算符。不同于隐式转换，显式转换运算符必须通过转换的方式来调用，如果缺少了显式的转换，在编译时就会产生错误。
## 委托，Lambda表达式和事件
* 委托
    * 委托是一种特殊类型的对象，其特殊性在于，我们以前定义的所有对象都包含数据，而委托包含的只是一个或者多个方法的地址。
    * 委托的类型安全性非常高，在定义它时，必须给出它的参数和返回类型。而C/C++只是一个指针，可以指向任何一个地址。
    * 定义一个委托其实是定义一个新的类，派生自`System.MulticastDelegate`。
    * 调用委托类的`Invoke()`和委托实例加`()`是完全相同的。
      ```C#
      firstStringMethod();
      firstStringMethod.Invoke();
      ```
    * 为减少输入量，在需要委托实例的每个位置可以只传入地址的名称，这称为委托推断。以下初始化是相同的作用。
      ```C#
      // new 委托实例
      GetAString firstStringMethod = new GetString(x.ToString);
      // 委托推断
      GetAString firstStringMethod = x.ToString;
      ```
    * `Action<T>`是没有返回的泛型委托，`Func<T>`是有返回值的泛型委托。它们都是最多可接受16种不同的参数。
      ```C#
      Func<double, double>[] operations = { MathOperations.MultiplyByTwo, MathOperations.Square}
      // 使用Func在以下方法中
      static void ProcessAndDisplayNumber(Func<double, double> action, double value)
      {
          double result = action(value);
          WriteLine(result);
      }
      ```
    * 多播委托就是一个委托包含多个方法，按照顺序连续调用。返回必须是`void`，否则只能得到委托调用的最后一个方法的结果。
      ```C#
      Action<double> operations = MathOperations.MultiplyByTwo;
      operations += MathOperations.Square;
      ```
    * 可以使用`GetInvocationList()`得到`Delegate`对象数据组。
      ```C#
      Action dl = One;
      dl += Two;
      Delegate[] delegates = dl.GetInvocationList();
      ```
    * 匿名方法。C# 2中引入，但是在C# 3.0后用lambda替代了。了解就行。
      ```C#
      Func<string, string> anonDel = delegate(string param){
          param += "string subfix";
      }
      ```
* **lambda**表达式
    * 单条代码。在方法内部需要花括号和`return`语句，因为编译器会添加一条默认的`return`语句。
      ```C#
      Func<double, double> square = x => x * x;
      // 等同于
      Func<double, double> square = x => { return x * x};
      ```
    * 多条代码就必须添加花括号和`return`了。
      ```C#
      Func<string, string> lambda = param => {
          param += mid;
          param += " and this was added to the string.";
          return param;
      }
      ```
    * 闭包。通过**lambda**表达式可以访问**lambda**表达式外部的变量。
        * 实现方式：是因为每个**lambda**表达式都会创建一个匿名类，编译器会创建一个构造函数来传递外部变量。
    * **lambda**可以用于类型为委托的任意地方。
* 事件
    * C/S应用事件，比如button事件
    * 用`event`关键字定义`EventHandler<TEvents>(object sender, TEventArgs e)`泛型。最新的lib，都已没有`where TEventArgs: EventArgs`约束。
      ```C#
      public event EventHandler<CarInfoEventArgs> NewCarInfo;
      ```
    * 参照代码sample
## 字符串和正则表达式
* `System.String`类
    * 是一个不可变的数据类型。一旦初始化，修改字符串或者运算符其实是新建一个字符串。
    * 如果频繁修改字符串，使用`StringBuilder`。它指定了内存大小，修改字符串是在其内存块中修改。当超过最大值时，它的容量会翻倍。
    * 如果不给`StringBuilder`设置初识容量，那该容量默认设置为16。
      ```C#
      var strBuilder = new StringBuilder("this is a string.", 150);
      ```
    * [NULL，""，String.Empty三者在C#中的区别](https://www.cnblogs.com/liuyaozhi/p/5809521.html)
* 字符串格式
    * 以下是相同的
      ```C#
      //$
      string s1 = "World";
      string s2 = $"Hello, {s1}";
      //StringFormat
      string s1 = "World";
      string s2 = String.Format("Hello, {0}", s1);
      ```
    * 转义花括号
      ```C#
      string s = "Hello";
      WriteLine($"{{s}} displays the value {s}");
      // {s} displays the value Hello
      ```
    * 大写字母`D`表示长日期格式字符串，小写字母`d`表示短日期字符串
      ```C#
      var day = new DateTime(2025, 2, 14);
      WriteLine($"{day:D}");
      WriteLine($"{day:d}");
      WriteLine($"{day:dd-MMM-yyyy}");
      // Friday, February 14, 2025
      // 2/14/2025
      // 14-Feb-2025
      ```
    * `n`表示数字格式，`e`表示指数格式，`x`表示16进制，`c`表示货币
      ```C#
      WriteLine($"{ i:n} , {i:e}, {i:x}, {i:c}");
      ```
    * `#`格式说明符是一个数字站位符，如果数字可用，就显示数字；如果数字不可用，不显示数字。`0`格式说明符是一个零占位符，显示相应数字，如果数字不存在，就显示零。
      ```C#
      double d = 3.1415926;
      WriteLine($"{d:###.###}");
      WriteLine($"{d:000.000}");
      ```
* 正则表达式
    * 是一种专门用于字符串处理的语言。
    * C# 名称空间: `System.Text.RegularExpression.RegEx`(更简单是调用其静态方法`Regex()`)
    * `pattern`字符串前用`@`。`const string pattern = @"\bn";`
    * ![主要的特定字符和转义序列](https://github.com/murdering/notes/blob/master/BasicAdvanced/Images/RegularExpression1.png)
    * ![主要的特定字符和转义序列补充](https://github.com/murdering/notes/blob/master/BasicAdvanced/Images/RegularExpression2.png)
## 集合
* 列表
    * 泛型类`List<T>`实现了`IList`,`ICollection`,`IEnumerable`,`IList<T>`,`ICollection<T>`,`IEnumerable<T>`。
    * 如果使用默认构造函数创建一个空列表，那它的初始容量是4，添加到第5个是，会扩容到8。以后每次扩容都是原来的2倍。
    * 以下是设置集合的容量
      ```C#
      List<int> intList = new List<int>(10);
      intList.Capacity = 20;
      ```
    * `intList.TrimExcess()`是去除不需要的容量，如果容量超过90%，就什么都不做。
    * `Predicate<T>`是一个委托，返回一个布尔值。返回`true`表示有匹配的元素，而且找到了；`false`表示没有找到，继续搜索。
      ```C#
      public int FindIndex(Predicate<T> math);
      // Predicate<T>等同于下
      public delegate bool Predicate<T>(T obj);
      ```
    * `Find()`，`FindIndex()`，`FindAll()`需要使用`Predicate<T>`类型参数，一般是用lambda。
    * 排序。和数组一样可以是实现`IComparable`和`IComparer`。此外还可以是用`Comparison<T>`委托。`Reverse()`同理可用。
      ```C#
      //Comparison<T>委托定义
      public void List<T>.Sort(Comparison<T>);
      //调用
      racers.Sort((r1,r2) => r2.Wins.CompareTo(r1.Wins));
      ```
* 队列`Queue<T>`
    * 先进先出。
    * 没有`Add()`,`Remove()`方法。只有用`Enqueue()`和`Dequeue()`来放在队尾和头部获取。
    * `Peek()`。从队列头部读取元素，但不删除。
* 栈`Stack<T>`
    * 后进先出。
    * 和`Queue<T>`类似，没有`Add()`,`Remove()`方法。只有用`Push()`和`Pop()`来放在z栈顶和从栈顶获取。
    * `Contains()`，确定某个元素是否在栈中。
* 链表`LinkedList<T>`
    * `LinkedList<T>`包含了`LinkedListNode<T>`类型的元素。`LinkedListNode`包含了上一个元素，下一个元素的信息。
    * 方法有`AddAfter()`,`AddBefore()`,`AddFirst()`,`AddLast()`,`Remove`,`RemoveFirst()`,`RemoveLast()`和`Find()`。
* 有序列表`SortedList<TKey, TValue>`
    * 值和键都可以是任意类型。
    * 需要传递实现了`IComparer<TKey>`接口的对象，该接口用于列表中的元素排序。
    * 一个键只能对应一个值。
    * 使用`foreach`语句时，用`KeyValuePair<TKey, TValue>`类型来接收返回的元素，如下。
      ```C#
      foreach(KeyValuePair<string, string>) book in books)
      {
          WriteLine($"{book.Key}, {book.Value}");
      }
      ```
* 字典`Dictionary<TKey, TValue>`
    * 键必须是有重写`GetHashCode()`方法。用`string`作为键非常方便和适用。
* `Lookup`类
    * 一个键对应多个值(一个集合)
    * 不能像一般的字典一样`new`创建，而必须要调用`ToLookup()`方法。
      ```C#
      var lookupRacers = racers.ToLookup(r => r.Country);
      foreach(Racer r in lookupRacers["Australia"])
      {
          WriteLine(r);
      }
      ```
* 有序字典`SortedDictionary<TKey, TValue>`
    * 和有序列表`SortedList<TKey, TValue>`类似，键必须实现`IComparable<TKey>`接口。
    * `SortedList<TKey, TValue>`实现为一个基于数组的列表，而`SortedDictionary<TKey, TValue>`是基于散列字典的，有以下不同特征
        * `SortedList<TKey, TValue>`使用的内存比`SortedDictionary<TKey, TValue>`少
        * `SortedDictionary<TKey, TValue>`的元素插入和删除比较快
        * 已排好序的数据填充集合时，若不修改容量，`SortedList<TKey, TValue>`比较快
* 集`HashSet<T>` `SortedSet<T>`
    * `HashSet<T>`包含不重复元素的**无序列表**，`SortedSet<T>`包含不重复元素的**有序列表**
* 集合性能
    * ![集合性能](https://github.com/murdering/notes/blob/master/BasicAdvanced/Images/集合性能.png)
## 特殊的集合
* 不变的集合
    * 命名空间`System.Collections.Immutable`
    * 多线程中使用，是不能改变的集合
    * 非泛型类`ImmutableArray`的`Create`静态方法会返回泛型`ImmutableArray`结构。
    * `ImmutableArray<T>`也有`Add()`,`Remove()`,`Replace()`方法，**但是它不是修改原有的结合，而是新建一个新的，然后返回**。
      ```C#
      //create
      ImmutableArray<string> a1 = ImmutableArray.Create<string>();
      //add
      ImmutableArray<string> a2 = a1.Add("Leo").Add("HeiHeiHei");
      ```
    * 普通集合`List<T>`可以用`ToImmutableList()`扩展方法创建一个不变的集合。
      ```C#
      ImmutableList<Account> immutableAccounts = accounts.ToImmutableList();
      ```
    * 可以用`ToBuilder()`创建一个可以改变的集合。反之，`Builder`的`ToImmutable()`方法，是创建一个新的不可变集合。
      ```C#
      ImmutableList<Accounts>.Builder builder = immutableAccounts.ToBuilder();
      for(int i = 0; i < builder.Count; i++)
      {
          Account a = builder[i];
          if(a.Amount < 0)
          {
              builder.Remove(a);
          }
      }
      ImmutableList<Account> overdrawnAccounts = builder.ToImmutable();
      overdrawnAccounts.ForEach(a => WriteLine($"{a.Name} {a.Amount}"));
      ```
    * 所有正常的集合类型都有不可变的结合，都是在前面添加`Immutable`，操作方法都是一样的。
## LINQ
* 延迟执行。因为使用`yield return`语句返回，所以在定义查询的时候，是不会执行的，而是在`foreach`语句中执行。或者在定义的时候用`ToList()`或者`ToArray()`马上返回遍历结果。但是结果可能有些许不一样。参照实例代码。
* 筛选。
    * 索引筛选。`Where()`方法的重载中，可以传递第二个参数--索引。如下：
      ```C#
      //形式以A开头，索引为偶数的赛车手
      var racers = Formular1.GetChampions().Where((r, index) => r.LastName.StartWith("A") && index %2 != 0);
      ```
    * 类型筛选。使用`OfType()`扩展方法，把类型传递到泛型参数。
      ```C#
      object[] data = {"one", 2, 3, "four", "five", 6};
      var query = data.ofType<string>();
      ```
* 排序。以下同义。
    ```C#
    // 1. 查询结果
    var racers = (from r in Formular1.GetChampions()
                    order by r.Country, r.LastName, r.FirstName
                    select r).Take(10);
    // 2. 扩展方法
    var racers = Formular1.GetChampions().OrderBy(r => r.Country)
                        .ThenBy(r => r.LastName)
                        .ThenBy(r => r.FirstName)
                        .Take(10);
    ```
* 分组。
    ```C#
    var countries = Formular1.GetChampions().GroupBy(r => r.Country)
                        .OrderByDescending(g => g.Count())
                        .TheBy(g => g.Key)
                        .Where(g => g.Count() >= 2)
                        .Select(g => new {
                            Country = g.Key,
                            Count = g.Count()
                        });
    ```
* 分区。`Take()`和`Skip()`。用于分页。
    ```C#
    int pageSize = 5;
    var racers = Formular1.GetChampions().OrderBy(r => r.Country)
                        .ThenBy(r => r.LastName)
                        .ThenBy(r => r.FirstName)
                        .Skip(pageNum * pageSize)
                        .Take(pageSize);
    ```
* **LINQ**中的变量使用。使用`let`来声明变量。
    ```C#
    var query = from r in Formular1.GetChampions()
                    let numberYears = r.Years.Count()
                    where numberYears >= 3
                    orderby numberYears descending, r.LastName
                    select new {
                        Name = r.FirstName + " " + r.LastName,
                        TimesChampion = numberYears
                    };
    ```
* `Range()`, `Empty()`和`Repeat`。`Empty()`是用于需要一个集合的参数，参数传值是空。
    ```C#
    var values = Enumerable.Range(1, 20).Select(n => n*3);
    ```
## 错误和异常
* 异常层次![异常层次](https://github.com/murdering/notes/blob/master/BasicAdvanced/Images/异常层次结构.png)
* `System.Exception`属性。`Data`，`Message`，`HelpLink`和`InnerException`属性必须在抛出前填充。
  
  | 属性 | 说明 |
  | ------ | ------ |
  | Data | 这个属性可以给异常添加键/值语句，以提供关于异常的额外信息 |
  | HelpLink | 连接到一个帮助文件，以提供关于该异常的更多信息 |
  | InnerException | 如果异常是在`catch`块中跑出的，它就会包含把代码发送到`catch`块中的异常对象 |
  | Message | 描述错误情况的文本 |
  | Source | 导致异常的应用程序名或对象名 |
  | StackTrace | 栈上方法调用的详细信息，它有助于跟踪跑出异常的方法 |
* 异常过滤器。在`catch`条件后添加`when()`条件。
  ```C#
    try
    {
        string input = string.Empty;
        WriteLine("pls input the error code.");

        input = ReadLine();

        if (string.IsNullOrEmpty(input)) break;

        int errorcode = Convert.ToInt32(input);

        throw new MyCustomException($"{input} MyCustomException") { ErrorCode = errorcode };
    }
    catch (MyCustomException ex) when (ex.ErrorCode == 405)
    {
        WriteLine($"MyCustomException is thrown, {ex.Message}");
    }
    catch (Exception ex)
    {
        WriteLine($"An exception was thrown, {ex.Message}");
    }
    finally
    {
        WriteLine("Thank you! \n");
    }
  ```
* 使用`throw`但不传递异常对象，会抛出当前异常。
## 异步编程
* .Net 2.0以前使用委托实现异步。
  ![.Net 2.0以前使用委托实现异步](https://github.com/murdering/notes/blob/master/BasicAdvanced/Images/.net1.0异步.png)
* 基于事件的异步编程。
    * `Async`方法调用完了后，会直接调用`Completed`事件。但是`Completed`委托必须实现在前。
  ![基于事件的异步编程](https://github.com/murdering/notes/blob/master/BasicAdvanced/Images/基于事件的异步编程.png)
* `Task.WhenAll`是同时执行两个任务。
  ```C#
  try
  {
      Task t1 = ThrowAfter(200, "first");
      Task t2 = ThrowAfter(500, "second");
      await Task.WhenAll(t1, t2);
  }
  catch (Exception e)
  {
      WriteLine("handled" + e.Message);
  }
  ```
* `lock`关键字。`lock(this)`, 静态锁和非静态锁的区别（参照MultiThread例子）。  
    1. `lock(this)`：是锁住当前整个实例，所有方法等待。
    2. `lock(object)`非静态锁：是锁住当前实例当前方法。
    4. `lock(staticObkect)`静态锁：是锁住所有实例的当前方法。

    **Reference:**
    * [C# 理解lock](https://www.cnblogs.com/gsk99/p/4964063.html)
    * [C#多线程，静态锁static lock和非静态锁lock的区别](https://blog.csdn.net/yongwuxin/article/details/41222639)
    * [C# Lock 关键字锁定静态变量和非静态变量的区别](https://blog.csdn.net/huijunma2010/article/details/53540606)
* 更多例子参照实例代码。






