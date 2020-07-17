using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyElephant.Services
{
    class MockOrderService : IOrderService
    {
        public void PlaceOrder(List<string> dishes)
        {

            //File.AppendAllLines(@"C:\Users\adam.wang\AWa\Software\VS\order.txt", dishes.ToArray());

            //FileStream fileStream = File.Create(@"C:\Users\adam.wang\AWa\Software\VS\order.txt");
            //
            //if (File.Exists(@"C:\Users\adam.wang\AWa\Software\VS\order.txt"))
            //{
            //
            //    fileStream.Write(new byte[] {20,10}, 0,0);
            //    //    
            //}
          StreamWriter writer =  File.CreateText(@"C:\Users\adam.wang\AWa\Software\VS\order.txt");

            writer.WriteLine("DFdsf");
        }

    }
}
