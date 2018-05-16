using ijse.pos.BLL.BusinessService.Contracts;
using ijse.pos.Common.Ioc;
using ijse.pos.Common.Model;
using ijse.pos.Service.Android.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ijse.pos.Service.Android.Controllers.API
{
    public class ItemController : ApiController
    {
        [Route("Item/{id}")]
        [HttpGet]
        public ApiItem FindItem(int id) {
            
            IItemManager ItemManager = UnityResolver.Resolve<IItemManager>("Items");
            Item item = ItemManager.SerchItem(id);

            ApiItem ritem = new ApiItem {
                Id = item.Id,
                AdditionalInfo=item.AdditionalInfo,
                ResourceDescription=item.ResourceDescription,
                ResourceType=item.ResourceType
            };

            return ritem;

        }
    }
}
