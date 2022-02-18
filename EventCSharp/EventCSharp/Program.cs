using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCSharp
{
  // public delegate void Sukiennhapso(int x);
/*
    pulisher -> class - phát đi sự kiện
    subsribẻr -> class - nhận sự kiện
 */
//publisher 
class Dulieunhap : EventArgs
    {
        public int data { get; set; }
        public Dulieunhap(int x) => data = x;
    }
class UserInput {
     //   public event Sukiennhapso sukiennhapso;
        public event EventHandler sukienhhapso;//~ delegate void KIEU(object? sender. EventArgs ar);
        public void Input()
        {
            do
            {
                Console.WriteLine("nhap vao mot so nguyen: ");
                string s = Console.ReadLine();
                int i = Int32.Parse(s);
                sukienhhapso?.Invoke(this,new  Dulieunhap(i)); //~ this tương đương Input
            } while (true);
        }
    }
    class Tinhcan
    {
        public void Sub1(UserInput input)
        {
            input.sukienhhapso += Can;
        }
        public void Can(object sender, EventArgs e)

        {
            Dulieunhap dulieunhap = (Dulieunhap)e;
            int i = dulieunhap.data;
            Console.WriteLine($"Can bac 2 cua {i} la {Math.Sqrt(i)}");
        }
    }
    class Tinhbinhphuong
    {
        public void Sub(UserInput input)
        {
            input.sukienhhapso += Binhphuong;
        }
        public void Binhphuong(object sender, EventArgs e)
        {
            Dulieunhap dulieunhap = (Dulieunhap)e;
            int i = dulieunhap.data;
            Console.WriteLine($"binh phuong cua {i} la {i*i}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.CancelKeyPress += (sender, e) =>
            {
                Console.WriteLine();
                Console.WriteLine("thoat ung dung");
            };
            UserInput userInput = new UserInput();
            userInput.sukienhhapso += (sender,e) =>
            {
                Dulieunhap dulieunhap = (Dulieunhap)e;
                int x = dulieunhap.data;
                Console.WriteLine($"ban vua nhap so :{x} ");
            };
            Tinhcan tinhcan1 = new Tinhcan();
             tinhcan1.Sub1(userInput);
            // userInput.Input();
            Tinhbinhphuong tinhbinhphuong = new Tinhbinhphuong();
            tinhbinhphuong.Sub(userInput);
            userInput.Input();
            
        }

    }
}
