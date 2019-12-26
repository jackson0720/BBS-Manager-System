using MISbbs.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MISbbs.Factory
{
    public class SessionValueProviderFactory: ValueProviderFactory
    {
        
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new SessionValueProvider();
        }
    }
}