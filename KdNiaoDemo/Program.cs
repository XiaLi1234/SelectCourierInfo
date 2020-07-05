using KdGoldAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KdNiaoDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //无限循环查询订单物流轨迹。
            while (true)
            {
                Seacher();
            }
        }

        public static void Seacher()
        {
            string dh = "";
            string phone = "";
            while (string.IsNullOrWhiteSpace(dh) || string.IsNullOrWhiteSpace(phone))
            {
                Console.WriteLine("请输入快递单号");
                dh = Console.ReadLine();
                Console.WriteLine("请输入手机号后四位");
                phone = Console.ReadLine();
            }
            if (!string.IsNullOrWhiteSpace(dh) && !string.IsNullOrWhiteSpace(phone))
            {
                KdApiSearchDemo demo = new KdApiSearchDemo();
                //string result = demo.getOrderTracesByJson(dh, phone);YT4305684277871
                string result = demo.getOrderTracesByJson(dh, phone,"SF");//.orderTracesSubByJson(dh);
                Console.WriteLine(result);
                Console.ReadLine();
            }
        }
    }
}
