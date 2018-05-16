using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using ijse.pos.DataAccess.DAL.Contract;
using ijse.pos.DataAccess.DAL;
using ijse.pos.Common.Utils.Log;
using ijse.pos.BLL.BusinessService.Contracts;
using ijse.pos.BLL.BusinessService;

namespace ijse.pos.Common.Ioc
{
    public class UnityResolver
    {
        private static readonly IUnityContainer Container = new UnityContainer();
        public static void Register() {

            Container.RegisterType<IRepository,Repository>();
            Container.RegisterType<ILogger, Log>();
            Container.RegisterType<IItemManager, ItemManager>();
           // IItemManager fp = new ItemManager();
            //Container.RegisterInstance<IItemManager>(fp);
        }

        public static T Resolve<T>()
        {
            
                T defaultT = default(T);

                var resolved = Container.Resolve<T>();
                return (resolved == null) ? defaultT : resolved;
            
        }

        public static IUnityContainer GetContainer()
        {
            return Container;
        }
    }
}
