using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp9.Models
{
    class CB_TypeOfDrug
    {
        public int id { get; set; }
        public string type { get; set; }

        public override string ToString()
        {
            return type;
        }
    }
}
