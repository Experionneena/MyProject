using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RI.SolutionOwner.WebAPI.Ingest.Models
{
    /// <summary>
    /// Service response container dto class.
    /// </summary>
    /// <typeparam name="TInstance">The type of the instance.</typeparam>
    public class MessageModel<TInstance>
    {
       
        public int Status { get; set; }

        public string Message { get; set; }

        public string MessageCode { get; set; }
    }
}