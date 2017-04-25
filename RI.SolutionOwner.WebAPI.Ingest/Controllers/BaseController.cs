﻿using System.Net;
using System.Net.Http;
using System.Web.Http;
using RI.SolutionOwner.WebAPI.Ingest.Models;
using RI.SolutionOwner.WebAPI.Ingest.Resources;

namespace RI.SolutionOwner.WebAPI.Ingest.Controllers
{
    /// <summary>
    /// BaseController class.
    /// </summary>
    public class BaseController : ApiController
    {
        /// <summary>
        /// Creates the HTTP response.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <param name="httpStatus">The HTTP status.</param>
        /// <param name="status">The status.</param>
        /// <param name="data">The data.</param>
        /// <param name="msg">The MSG.</param>
        /// <returns>returns HttpResponseMessage.</returns>
        public HttpResponseMessage CreateHttpResponse<TInstance>(HttpStatusCode httpStatus, HttpCustomStatus status, TInstance data, string msg)
        {
            var response = new HttpResponseMessage();
            response.StatusCode = httpStatus;

            if (httpStatus == HttpStatusCode.OK || httpStatus == HttpStatusCode.Created || httpStatus == HttpStatusCode.Accepted || httpStatus == HttpStatusCode.NoContent || httpStatus == HttpStatusCode.NotFound || httpStatus == HttpStatusCode.NotModified)
            {
                response = Request.CreateResponse(data);
                response.ReasonPhrase = msg;
                response.StatusCode = httpStatus;

                return response;
            }
            else
            {
                response.ReasonPhrase = msg;
                response = Request.CreateResponse(data);
                response.StatusCode = httpStatus;
            }
            return response;
        }

        /// <summary>
        /// Gets the localised string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>returns the string message.</returns>
        public static string GetLocalisedString(string key)
        {
            return MessageResource.ResourceManager.GetString(key);
        }
    }
}