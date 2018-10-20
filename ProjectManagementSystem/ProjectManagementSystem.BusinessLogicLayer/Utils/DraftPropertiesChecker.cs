using ProjectManagementSystem.Model;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagementSystem.BusinessLogicLayer.Exceptions;
using ProjectManagementSystem.Draft;

namespace ProjectManagementSystem.BusinessLogicLayer.Utils
{
    public class DraftPropertiesChecker
    {
        private const string propertyNotFilled = "Property {0} not filled! It is null then system can't work without this value.";

        public static void Check(IDraft draft)
        {
            foreach(PropertyInfo prop in draft.GetType().GetProperties())
            {
                if(prop.GetValue(draft) == null)
                {
                    throw new PropertyNotFilledException(string.Format(propertyNotFilled, prop.Name), prop.Name);
                }
            }
        }
    }
}
