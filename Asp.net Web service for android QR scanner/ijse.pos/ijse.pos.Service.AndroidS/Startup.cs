using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ijse.pos.Service.AndroidS.Startup))]

namespace ijse.pos.Service.AndroidS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        //public Startup(IApplicationEnvironment env,
        //           IHostingEnvironment hostenv, ILoggerFactory logger)
        //{
        //}
    }
}
