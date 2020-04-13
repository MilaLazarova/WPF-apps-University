using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {

       public String name
        { get; set; }
       public String pass { get; set; }
        public String facNum { get; set; }
       public int role { get; set; }
       public DateTime Created { get; set; }
       public DateTime ValidTill { get; set; }



    }
}
