using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17
{
    /*
     * Создать класс для моделирования счета в банке. 
     * Предусмотреть закрытые поля для номера счета, баланса, ФИО владельца.  
     * Класс должен быть объявлен как обобщенный. 
     * Универсальный параметр T должен определять тип номера счета. 
     * Разработать  методы  для  доступа  к  данным  –  заполнения  и  чтения. 
     * Создать  несколько экземпляров класса, параметризированного различными типам. 
     * Заполнить его поля и вывести информацию об экземпляре класса на печать.
     */
    class Program
    {
        static void Main(string[] args)
        {
            BankData<int> bankData1 = new BankData<int>();
            string[] person1 = { "Петров", "Петр", "Петрович" };
            bankData1.FullName = person1;
            bankData1.Balance = 250000.25;
            bankData1.PersonAccaunt = 140785320;
            
            BankData<string> bankData2 = new BankData<string>();
            string[] person2 = { "Иванов", "Иван", "Иванович" };
            bankData2.FullName = person2;
            bankData2.Balance = 0.25;
            bankData2.PersonAccaunt = "к/р сч. 1235478468100000005456";

            BankData<long> bankData3 = new BankData<long>();
            string[] person3 = { "Анисимов", "Анисин", "Анисимович" };
            bankData3.FullName = person3;
            bankData3.Balance = 1250014.65;
            bankData3.PersonAccaunt = 4007845210000001465;            

            bankData1.Print();
            bankData2.Print();
            bankData3.Print();
            Console.ReadKey();
        }
    }
    public class BankData<T>
    {
        double balance;
        string lastName;
        string firstName;
        string patron;
        T personAccaunt;

        public string[] FullName
        {
            set
            {
                if (value.Length > 0)
                {
                    lastName = value[0];
                    firstName = value[1];
                    patron = value[2];
                }
            }
            get
            {
                string[] fullName = new string[3];
                fullName.Append<string>(lastName);
                fullName.Append<string>(firstName);
                fullName.Append<string>(patron);

                return fullName;
            }
        }
        public T PersonAccaunt { set; get; }
        public double Balance
        {
            get
            {
                return balance;
            }
            set
            {
                if (value > 0)
                {
                    balance = value;
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("Клиент: {0} {1} {2}", lastName, firstName, patron);
            Console.WriteLine("      Счёт: {0}", PersonAccaunt);
            Console.WriteLine("      Остаток по счёту: {0}", balance);
        }
    }
}
