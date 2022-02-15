using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDelegate
{
    // delegate (type: loại kiểu trả về) bien = phuongthuc sau đó có thể dùng bien đê thực hiện các thao tác trong phương thức
    public delegate void Showlog(string message);// được dùng để tham chiếu đến các phương thức nhưng phải tương đồng với kiểu delegate showlog
    //void Showlog(string message)
    class Program
    {
        static void Warning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        static void Info(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        delegate int Kieu();
        static int Tong(int a, int b) => a + b;
        static int Hieu(int a, int b) => a - b;//arrow function trả về sau =>
        static void Tong1(int a, int b,Showlog showlog)
        {
           int kq = a + b;
            showlog?.Invoke($"Kết quả :{kq}" );
        }
        static void Main(string[] args)
        {
            /*Showlog log = null; // delegate có thể tạo ra một chuỗi tham chiếu bằng cách dùng +=
            //log = Info;
            // if (log != null)
            //   {
            //      log("Xin chao");
            //       log.Invoke("Xin chao 1");
            //   }
            //log? tương tự if(log!=null)
            log += Info; // một phương thức có thể gọi nhiều lần
            log += Warning;
            //log vừa tham chiếu đến info và warning
            log?.Invoke("Xin chào ABC");//Tương tự cái trên*/
            //Action , Func : thư viện định nghĩa sẵn của dotnet delegate - generic
            Action action; // ~ delegate void KIEU()
            Action<string, int> action1; //~ delegate void KIEU(string s , int i)
            Action<String> action2;//~ delegate void KIEU(string s)
            action2 = Warning;
            action2 += Info;
            action2?.Invoke("Thông báo từ Action");
            //dùng Func phải có kiểu trả về
            Func<int> f1;//int là kiểu trả về  ~ delegate int KIEU()
            Func<string, double, string> f2;//kiểu trả về đc liệt kê ở cuối cùng //~delegate string KIEU(string s, double d)
            Func<int, int, int> TinhToan;
            int a = 5;
            int b = 10;
            TinhToan = Tong;
            Console.WriteLine($"Tong la {TinhToan(a,b)}");
            Tong1(4, 5, Warning);
            Console.ReadLine();
        }
    }
}
