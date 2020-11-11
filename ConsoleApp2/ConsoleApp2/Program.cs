using System;

namespace ConsoleApp2
{
    class Reaction
    {
        public string str;
        public float age;
        public float value_age 
        { 
            get 
            {
                return age;
            }
            set
            {
                if (value != Int32.MaxValue || value < Int32.MaxValue || value > 0 || value > 150)
                    age = value;
                else
                {
                    Console.WriteLine("Uncorrected value");
                }
            }
        }
        public void Method_New_Propirtes_Method(float value)
        {
            value_age = value;
        }
        public void MessageRename()
        {
            str = Console.ReadLine();
        }
    }
    class Programmer 
    {
        public delegate void Rename();
        public delegate void New_Properties(float value);
        public event Rename rename;                     //Событие rename c типом делегата Rename.
        public event New_Properties new_properties;     //Событие new_properties c типом делегата New_Properties.
        public void MethodRename()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 91)
                {
                    Console.Write("Enter new name: ");
                    rename();
                }
            }
        }
        public void Method_New_Propirtes(float value)
        {

            if(value != Int32.MaxValue || value <= 0 || value > 150) 
                new_properties(value);
            else{
                Console.WriteLine("Value wasnt saved");
            }
        }
    }
    class Program
    {
        delegate int Operation(int x, int y);
        static void Main(string[] args)
        {
            Operation operation = (x, y) => x + y;      //лямбда выражение 
            Console.WriteLine("Result first lambda operation: " + operation(10, 20));           // 30
            Console.WriteLine("Result second lambda operation: " + operation(40, 20));          // 60

            Programmer reaction_1 = new Programmer();
            Programmer reaction_2 = new Programmer();
            Reaction react = new Reaction();

            reaction_1.rename += react.MessageRename;
            reaction_2.new_properties += react.Method_New_Propirtes_Method;

            reaction_1.MethodRename();
            Console.Write("Enter float value: ");
            float value = float.Parse(Console.ReadLine());
            reaction_2.Method_New_Propirtes(value);

            Console.Write("\nEnter string with punctuation marks: ");
            string str = Console.ReadLine();
            Func<string , string> retFunc = WwS;
            str = retFunc(str);
            Console.WriteLine(str);

            retFunc = Wz;
            retFunc(str);
            Console.WriteLine(str);

            retFunc = replacement;
            retFunc(str);
            Console.WriteLine(str);

            Console.WriteLine("End");
            Console.Read();
        }
        static string WwS(string str)
        {
            char[] c = str.ToCharArray();
            int p = 0;
            for (int i = 0; i < str.Length - p; i++)
            {
                if (c[i] == '.' || c[i] == ',' || c[i] == '!' || c[i] == '?')
                {
                    for (int j = i; j < str.Length; j++)
                    {
                        if (j < str.Length - 1)
                            c[j] = c[j + 1];
                    }
                    i = 0;
                    p++;
                }
            }
            char[] c_ = new char[str.Length - p];
            for(int i = 0; i< str.Length - p; i++)
            {
                c_[i] = c[i];
            }
            str = new string(c_);
            return str;
        }
        static string Wz(string str)
        {
            string newtext = "";
            for (int i = 0; i < str.Length; i++)
                if (str[i] != str.ToUpper()[i])
                    newtext += str.ToUpper()[i];
            return newtext;
        }
        static string replacement(string str)
        {
            char[] c = str.ToCharArray();
            int p = 0;
            string s;
            for (int i = 0; i < str.Length - p; i++)
            {
                if (c[i] == ' ' && i != str.Length - p - 1)
                {
                    c[i] = c[i + 1];
                    s = new string(c);
                    p++;
                }
            }
            char[] c_ = new char[str.Length - p];
            for (int i = 0; i < str.Length - p; i++)
            {
                c_[i] = c[i];
            }
            str = new string(c_);
            return str;
        }
    }
}