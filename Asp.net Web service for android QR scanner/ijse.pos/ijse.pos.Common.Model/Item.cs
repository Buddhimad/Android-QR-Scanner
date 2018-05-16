using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijse.pos.Common.Model
{
    public class Item
    {
        public int Id { get; set; }

        public String ResourceType { get; set; }

        public String ResourceDescription { get; set; }

        public String AdditionalInfo { get; set; }
    }
}
