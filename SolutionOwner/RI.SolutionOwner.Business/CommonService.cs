using RI.SolutionOwner.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RI.SolutionOwner.Data.Services.Contracts;
using RI.SolutionOwner.Business.Contracts;

namespace RI.SolutionOwner.Business
{
   public class CommonService: ICommonService
    {
        private ICommonDataService _service;
        public CommonService(ICommonDataService service)
        {
            _service = service;
        }
              
        public async Task<IEnumerable<ICurrency>> GetBaseCurrency()
        {
            return await _service.GetBaseCurrency();
        }

    }
}
