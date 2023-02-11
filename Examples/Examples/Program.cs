using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Examples
{
    class BaseClass
    {
        public int BaseField = 0;
    }
    class DerivedClass : BaseClass
    {
        public int DerivedField = 0;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var bc = new BaseClass();
            var dc = new DerivedClass();

            var bca = new BaseClass[] {bc, dc};

            foreach (var instance in bca)
            {
                var t = instance.GetType();
                Console.WriteLine($"Object type : {t.Name}");
                
                FieldInfo[] fi = t.GetFields();
                foreach (var fieldInfo in fi)
                {
                    Console.WriteLine($"    Field : {fieldInfo.Name}");
                }

                Console.WriteLine();
            }

            Type tbc = typeof(DerivedClass); // Get the type.
            Console.WriteLine($"Object type : {tbc.Name}");
            FieldInfo[] fiUsingTypes = tbc.GetFields();
            foreach (var f in fiUsingTypes)
            {
                Console.WriteLine($" Field : {f.Name}");
            }
        }
    }
}