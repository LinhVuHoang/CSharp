using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Action<string> ThongBao;*/
            Action ThongBao;
            /*ThongBao = (string s) => Console.WriteLine(s)*/; //~delegate void Kieu(string s) = Action<String>
                                                               // ThongBao?.Invoke("Xin chào");
                                                                ThongBao = () => Console.WriteLine("Xin chào các bạn");
                                                               // ThongBao?.Invoke();
            Action<string> welcome;
            welcome = (string s) => Console.WriteLine(s); // hoặc welcome = (s) => Console.WriteLine(s); hoặc welcome =  s => Console.WriteLine(s);
            welcome?.Invoke("Xin chao cac ban");
            Action<string, string> welcome1;
            /*welcome1 = ( mgs, name) => Console.WriteLine(mgs +" "+ name);
            welcome1?.Invoke("Xin chao", "linh");
            welcome1?.Invoke("Tam biet", "Nam");*/
            welcome1 = (mgs, name) =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(mgs + " " + name);
                Console.ResetColor();
            };
            welcome1?.Invoke("Xin chao", "linh");
            welcome1?.Invoke("Tam biet", "Nam");
            /*(int a, int b) =>
            {
                int kq = a + b;
                return kq;
            }*/
            Func<int, int, int> tinhtoan;
            tinhtoan = (int a, int b) =>
            {
                int kq = a + b;
                return kq;
            };
            Console.WriteLine(tinhtoan.Invoke(5,6));
            int[] mang = { 2, 4, 9, 16, 25, 36 };
            var kq1 = mang.Select((int x) => //chọn từng phần tử của mảng
            {
                return Math.Sqrt(x);
            });
            foreach (var result in kq1)
            {
                Console.WriteLine(result);
            }
            mang.ToList().ForEach(
                (x) =>
                {
                    if(x%2 !=0)
                    {
                        Console.WriteLine(x);
                    }
                }
                ); //duyệt qua từng phần tử của danh sách
           var kq2 = mang.Where(
                (x) =>
                {
                    return x % 4 == 0;
                }            
            );
            foreach(var n in kq2){
                Console.WriteLine(n);
            }
            var kq3 = mang.Where(x => x >= 2 && x <= 10);
            foreach(var n in kq3)
            {
                Console.WriteLine(n);
            }
            Console.ReadLine();
        }
    }
}
