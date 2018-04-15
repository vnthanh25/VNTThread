using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNTThread
{
    class Program
    {
        static void Main(string[] args)
        {
            List<System.Threading.Thread> lstThread = new List<System.Threading.Thread>();
            List<string> lstParam = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                System.Threading.Thread oThread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(MtdCallWebServer));
                Console.WriteLine("start : " + i.ToString());
                oThread.Start(i.ToString());
                Console.WriteLine("end : " + i.ToString());
                oThread.Join();
                Console.WriteLine("end join : " + i.ToString());
                lstThread.Add(oThread);
                lstParam.Add(i.ToString());
            }
            //MtdCallListThread(lstThread, lstParam);
            Console.WriteLine("end main.");
            Console.ReadLine();
        }
        public static void MtdCallListThread(List<System.Threading.Thread> pLstThread, List<string> pLstParam)
        {
            for (int i = 0; i < pLstThread.Count; i++)
            {
                Console.WriteLine("start : " + i.ToString());
                pLstThread[i].Start(pLstParam[i]);
                Console.WriteLine("end : " + i.ToString());
                pLstThread[i].Join();
                Console.WriteLine("end join : " + i.ToString());
            }
        }
        public static void MtdCallWebServer(object pNewsId)
        {
            Console.WriteLine("Begin Sleep.");
            System.Threading.Thread.Sleep(10000);
            Console.WriteLine("End Sleep.");
        }
    }
}
