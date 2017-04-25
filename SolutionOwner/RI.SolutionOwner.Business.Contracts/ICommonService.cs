using RI.SolutionOwner.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.SolutionOwner.Business.Contracts
{
   public interface ICommonService
    {
      Task<IEnumerable<ICurrency>> GetBaseCurrency();
    }
}
