using ijse.pos.BLL.BusinessService.Contracts;
using ijse.pos.Common.Ioc;
using ijse.pos.Common.Model;
using ijse.pos.Service.AndroidS.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ijse.pos.Service.AndroidS.Controllers.API
{
    public class ItemController : ApiController
    {
        [HttpGet]
        public ApiItem Search(int id) {
            IItemManager ItemManager = UnityResolver.Resolve<IItemManager>();
            Item item = ItemManager.SerchItem(id);
            ApiItem apiitem = new ApiItem {
                Id = item.Id,
                ResourceType=item.ResourceType,
                ResourceDescription=item.ResourceDescription,
                AdditionalInfo=item.AdditionalInfo
            };
            return apiitem;

        }
    }
}
