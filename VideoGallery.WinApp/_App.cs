using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGallery.WinApp.Data;

namespace VideoGallery.WinApp
{
   public class _App
    {
       public static VgmsDbContext VgmsDb=new VgmsDbContext();
        public static string UserFullName = "Not Login";
        public static string UserName ="TempUser";
        public static int ID = 0;
    }
}
