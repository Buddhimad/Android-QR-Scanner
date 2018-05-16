using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ijse.pos.Service.WebApi.Models.API
{
    public class ApiItemModel
    {
        public int Id { get; set; }

        public String ResourceType { get; set; }

        public String ResourceDescription { get; set; }

        public String AdditionalInfo { get; set; }
    }
}