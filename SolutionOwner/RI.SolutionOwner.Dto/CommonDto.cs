using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.SolutionOwner.Dto
{
    public class CommonDto<TData>
    {
        public CommonDto()
        {
           
        }

        public Status Status { get; set; } = Status.Success;

        public String Message { get; set; }

        public TData Data { get; set; }


    }
    public enum Status
    {
        Success,
        Failed,
        Error,
        Warning,
        Question,
        Exception
    }
}
