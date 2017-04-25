using RI.Framework.Core.Logging.Contracts;
using RI.SolutionOwner.Business.Contracts;
using RI.SolutionOwner.Data.Contracts;
using RI.SolutionOwner.WebAPI.Extensions;
using RI.SolutionOwner.WebAPI.Ingest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace RI.SolutionOwner.WebAPI.Ingest.Controllers
{
    public class SPAddressController : BaseController
    {
        #region Private Members
        /// <summary>
        /// Private member _logger
        /// </summary>
        private ILoggerExtension logger;

        /// <summary>
        /// The address service
        /// </summary>
        private ISPAddressService addressService;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SPAddressController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="addressService">The address service.</param>
        public SPAddressController(ILoggerExtension logger, ISPAddressService addressService)
        {
            this.logger = logger;
            this.addressService = addressService;
        }
        #endregion

        #region public Functions

        /// <summary>
        /// Creates the address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("SPAddress/CreateAddress")]
        public HttpResponseMessage CreateAddress([ModelBinder(typeof(IocCustomCreationConverter))] ISPAddress address)
        {
            try
            {
                var createdAddress = addressService.CreateSPAddress(address);

                if (createdAddress == null)
                {
                    return CreateHttpResponse<ISPAddress>(HttpStatusCode.BadRequest, HttpCustomStatus.Failure, address, GetLocalisedString("msgWebServiceError"));
                }
                else
                {
                    return CreateHttpResponse<ISPAddress>(HttpStatusCode.Created, HttpCustomStatus.Success, address, GetLocalisedString("msgSPAddressCreation"));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Gets the address by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("SPAddress/GetAddressById/{id}")]
        public async Task<HttpResponseMessage> GetAddressById(int id)
        {
            try
            {
                var address = await addressService.GetAddressById(id);
                if (address != null)
                {
                    return CreateHttpResponse<ISPAddress>(HttpStatusCode.OK, HttpCustomStatus.Success, address, GetLocalisedString("msgSuccess"));
                }
                else
                {
                    return CreateHttpResponse<ISPAddress>(HttpStatusCode.BadRequest, HttpCustomStatus.Failure, address, GetLocalisedString("msgWebServiceError"));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Gets all address.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("SPAdress/GetAllAddress")]
        public async Task<HttpResponseMessage> GetAllAddress()
        {
            try
            {
                var addressList = (await addressService.GetAllAddress()).ToList();
                if (addressList.Count != 0)
                {
                    return CreateHttpResponse<IEnumerable<ISPAddress>>(HttpStatusCode.OK, HttpCustomStatus.Success, addressList, GetLocalisedString("msgSuccess"));
                }
                else
                {
                    return CreateHttpResponse<IEnumerable<ISPAddress>>(HttpStatusCode.NoContent, HttpCustomStatus.Failure, addressList, GetLocalisedString("msgWebServiceError"));
                }
            }

            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, GetLocalisedString("msgWebServiceError"));
            }
        }

        /// <summary>
        /// Updates the address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("SPAddress/UpdateAddress")]
        public async Task<HttpResponseMessage> UpdateAddress(ISPAddress address)
        {
            try
            {
                var addressUpdated = await addressService.UpdateAddress(address);
                if (addressUpdated)
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.Accepted, HttpCustomStatus.Success, addressUpdated, GetLocalisedString("msgSPAddressUpdation"));
                }
                else
                {
                    return CreateHttpResponse<bool>(HttpStatusCode.BadRequest, HttpCustomStatus.Failure, addressUpdated, GetLocalisedString("msgWebServiceError"));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return CreateHttpResponse<bool>(HttpStatusCode.InternalServerError, HttpCustomStatus.Failure, false, GetLocalisedString("msgWebServiceError"));
            }

        }
        #endregion
    }
}
