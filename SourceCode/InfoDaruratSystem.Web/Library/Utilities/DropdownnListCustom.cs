using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoDaruratSystem.Web.Library.Utilities
{
    public class DropdownnListCustom
    {

        public static List<string> GetQuestion()
        {
            List<string> list = new List<string>();
            list.Add("What is your favourite colour?");
            list.Add("What is your favourite songs?");
            list.Add("What is your favourite food?");

            return list;
        }

    }
}
