using APS4.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APS4
{
    public class Constantes
    {
        public static string BaseApiAddress => "http://172.17.0.62:8082/";
        public static User CurrentUser = null;
        public static int AdminId = 233;

        public int getAdminId()
        {
            return 0;
        }
    }
}