using ijse.pos.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ijse.pos.BLL.BusinessService.Contracts
{
    public interface IItemManager
    {
         Item SerchItem(int id);
        bool AddItem(Item item);
    }
}
