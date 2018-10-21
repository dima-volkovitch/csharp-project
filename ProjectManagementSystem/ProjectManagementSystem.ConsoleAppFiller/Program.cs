using Newtonsoft.Json;
using ProjectManagementSystem.BusinessLogicLayer;
using ProjectManagementSystem.BusinessLogicLayer.Token;
using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManagementSystem.ConsoleAppFiller
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            Thread.Sleep(300);
            Console.WriteLine(DateTime.Now);
        }
    }
}
