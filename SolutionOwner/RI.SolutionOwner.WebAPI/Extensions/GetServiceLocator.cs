using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RI.SolutionOwner.WebAPI.Extensions
{
    public static class GetServiceLocator
    {
        public static IServiceProvider Instance { get; set; }
    }
}