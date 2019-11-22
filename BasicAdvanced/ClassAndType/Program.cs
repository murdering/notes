using static System.Console;

namespace ClassAndType
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 属性
            PropertyFunction();

            // params 关键字
            ParamsFunction(1, 2, 3);
            ParamsFunction2(null);
            Math math = null;
            ParamsFunction2(math);

            // readonly
            ReadOnlyFunction();

            // Struct
            StructFunction();

            // Enum
            EnumFunction();

            // 扩展方法
            ExtensionFunction();

            ReadLine();
        }

        public static void PropertyFunction()
        {
            WriteLine($"PI is {Math.GetPi()}");
            WriteLine($"Square of 5 is : {Math.GetSquareOf(5)} ");
            var math = new Math();
            math.Value = 6;
            WriteLine($"Value of Math is : {math.Value}");
            WriteLine($"Square of Math Value is : {math.GetSquare()}");

            // 带参数名字, 默认值, 并且可以乱序
            WriteLine($"Divide of Value 5 with default is : {Math.GetDivid(5)}");
            WriteLine($"Divide of Value 5 with default is : {Math.GetDivid(numerator: 2, denominator: 5)}");
        }

        // params 关键字
        public static void ParamsFunction(params int[] array)
        {
            foreach (var i in array)
            {
                WriteLine($"params item: {i}");
            }
        }

        public static void ParamsFunction2(params Math[] array)
        {
            if (array == null)
            {
                WriteLine("maths is null");
                return;
            }

            foreach (var math in array)
            {
                if (math == null)
                {
                    WriteLine("math is null");
                }
                else
                {
                    WriteLine("math is not null ");
                }
            }
        }

        // readonly
        public static void ReadOnlyFunction()
        {
            WriteLine("######################Readonly function Start#############################");
            var readonlySample = new ReadOnlySample("Leo", "Dai");
            //readonlySample.FirstName = "";

            WriteLine(readonlySample.Id);
            WriteLine(readonlySample.FullName);
            WriteLine(ReadOnlySample.StartTime);
            WriteLine(ReadOnlySample.DayOfWeek);
        }

        // Struct
        public static void StructFunction()
        {
            WriteLine("######################Struct function Start#############################");
            TestStruct testStruct;
            //WriteLine($"Test Struct Width: {testStruct.Width}, Height:{testStruct.Height} ");

            testStruct.Height = 10;
            testStruct.Width = 20;
            WriteLine($"Test Struct Width: {testStruct.Width}, Height:{testStruct.Height} ");

            testStruct = new TestStruct();
            TestClass testClass = new TestClass(10, 20);
        }

        // Enum
        public static void EnumFunction()
        {
            WriteLine("######################Enum function Start#############################");
            ColorEnum color = ColorEnum.Blue;

            WriteLine($" Color Enum value: {(short)color}");
            WriteLine($" Color Enum string: {color}");
        }

        // 部分类
        public static void PartialFunction()
        {
            var partialClass = new PartialClass();

            partialClass.MethodOne();
        }

        // 扩展方法
        public static void ExtensionFunction()
        {
            WriteLine("######################Extension function Start#############################");

            var str = "aaaaa";
            WriteLine($"hello world! : {str.GetWordCount()}");
        }
    }
}