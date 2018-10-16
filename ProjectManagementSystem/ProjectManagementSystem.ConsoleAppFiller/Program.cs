using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.ConsoleAppFiller
{
    public class Program
    {
        public static void Main(string[] args)
        {
            User Dima = new User()
            {
                FirstName = "Dmitry",
                LastName = "Volkovitch",
                Patronymic = "Victorovich",

                Login = "volkfar",
                
            };
        }
    }
}
