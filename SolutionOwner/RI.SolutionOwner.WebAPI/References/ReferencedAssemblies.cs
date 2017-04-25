using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace RI.SolutionOwner.WebAPI.References
{
    public static class ReferencedAssemblies
    {
        public static Assembly BusinessDto
        {
            get
            {
                return Assembly.Load("RI.SolutionOwner.Business");
            }
        }

        public static Assembly DataServices
        {
            get
            {
                return Assembly.Load("RI.SolutionOwner.Data.Services");
            }
        }

        public static Assembly DomainEntities
        {
            get
            {
                return Assembly.Load("RI.SolutionOwner.Data");
            }
        }
    }
}