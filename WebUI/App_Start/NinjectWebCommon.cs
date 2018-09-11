using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;

namespace WebUI.App_Start
{
    public class NinjectWebCommon
    {

        private static void RegisterServices(IKernel kernel)
        {
            System.Web.Mvc.DependencyResolver.SetResolver(new Infrastructure.NinjectDependencyResolver(kernel));
        }
    }
}