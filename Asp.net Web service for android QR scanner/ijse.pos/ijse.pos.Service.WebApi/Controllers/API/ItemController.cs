using ijse.pos.BLL.BusinessService;
using ijse.pos.BLL.BusinessService.Contracts;
using ijse.pos.Common.Ioc;
using ijse.pos.Common.Model;
using ijse.pos.Service.WebApi.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ijse.pos.Service.WebApi.Controllers.API
{
    public class ItemController : ApiController
    {
        public ApiItemModel Search(int id)
        {
            IItemManager ItemManager = UnityResolver.Resolve<IItemManager>();

            Item item=ItemManager.SerchItem(id);
            ApiItemModel aitem = new ApiItemModel {
                Id = item.Id,
                ResourceType = item.ResourceType,
                ResourceDescription=item.ResourceDescription,
                AdditionalInfo=item.AdditionalInfo
            };
            return aitem;

        }
        public void Add() {
            IItemManager ItemManager = UnityResolver.Resolve<IItemManager>();
            Item i = new Item {Id=1,ResourceType="vodka",ResourceDescription="alchohol",AdditionalInfo="Russia" };

            ItemManager.AddItem(i);

        }
    }
}
