using ijse.pos.BLL.BusinessService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ijse.pos.Common.Model;
using ijse.pos.Common.Utils.Log;
using ijse.pos.DataAccess.DAL.Contract;

namespace ijse.pos.BLL.BusinessService
{
    public class ItemManager : IItemManager
    {
        private ILogger log;
        private IRepository repository;

        public ItemManager() { }
        public ItemManager(ILogger log,IRepository repository) {
            this.log = log;
            this.repository = repository;
        }

        public bool AddItem(Item item)
        {
            return repository.Create<Item>(item);
        }

        public Item SerchItem(int id)
        {
            return repository.Find<Item>(I=>I.Id==id);
        }
    }
}
