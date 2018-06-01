using ClassLibrary1.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Service
    {
        MyClassReflection myClass = new MyClassReflection();

        public void ServiceAddInfo()
        {
            Console.WriteLine("================== Добавление информации о пользователе ==================");
            Console.WriteLine();
            Console.Write("Введите имя: ");
            myClass.Name = Console.ReadLine();
            Console.Write("Введите Фамилию: ");
            myClass.SurName = Console.ReadLine();
            Console.Write("Введите возраст: ");
            myClass.Age = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("================== Информация добавлена успешно! ==================");
            Console.WriteLine();
            Thread.Sleep(1500);

            ServiceReflection();
        }

        public void ServiceReflection()
        {
            Console.Clear();
            Console.WriteLine("1 - Вывести методы класса Console\n2 - Получить свойства и их значения из класса\n3 - Вызвать метод Substring\n4 - Получить список конструкторов класса List<T>");
            string ch = Console.ReadLine();
            switch (ch)
            {
                case "1":
                    {
                        #region
                        Type cons = typeof(Console);
                        MethodInfo[] methArr = cons.GetMethods();
                        foreach (var item in methArr)
                        {
                            Console.Write("----> {0}(", item.Name);
                            ParameterInfo[] p = item.GetParameters();
                            for (int i = 0; i < p.Length; i++)
                            {
                                Console.Write("{0} {1}", p[i].ParameterType.Name, p[i].Name);
                                if (i + 1 < p.Length)
                                    Console.Write(", ");
                            }
                            Console.WriteLine(") ");
                        }
                        #endregion
                    }
                    break;
                case "2":
                    {
                        #region
                        Type m = typeof(MyClassReflection);
                        FieldInfo[] fNames = m.GetFields();
                        foreach (var f in fNames)
                        {
                            Console.Write("--> {0} {1} = {2}\n", f.FieldType.Name, f.Name, f.GetValue(myClass));
                        }
                        #endregion
                    }
                    break;
                case "3":
                    {
                        #region
                        Type t = typeof(String);
                        Type[] parameterTypes = { typeof(int) };
                        MethodInfo sub = t.GetMethod("Substring", parameterTypes);
                        Console.Write("Введите строку: ");
                        string str = Console.ReadLine();
                        Console.Write("Введите аргумент: ");
                        int arg = int.Parse(Console.ReadLine());
                        object[] arguments = { arg };
                        object returnValue = sub.Invoke(str, arguments);
                        Console.WriteLine(returnValue);
                        #endregion
                    }
                    break;
                case "4":
                    {
                        #region
                        Type l = typeof(List<>);
                        ConstructorInfo[] constructors = l.GetConstructors();

                        foreach (var con in constructors)
                        {
                            Console.Write("----> {0}(", con.Name);
                            ParameterInfo[] p = con.GetParameters();
                            for (int i = 0; i < p.Length; i++)
                            {
                                Console.Write("{0} {1}", p[i].ParameterType.Name, p[i].Name);
                                if (i + 1 < p.Length)
                                    Console.Write(", ");
                            }
                            Console.WriteLine(") ");
                        }
                        #endregion
                    }
                    break;
            }
        }
    }
}
