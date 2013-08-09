using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.MainModule.Bundles;
using Domain.MainModule.Entities;
using Infrastructure.CrossCutting.IoC;
using DistributedServices.Entities;
using DistributedServices.Api.Mappings;
using AttributeRouting.Web.Http;
using Domain.MainModule.Clients;

namespace DistributedServices.Api.Controllers
{
    public class ClientsController : ApiController
    {
        private readonly IClientService _service;

        public ClientsController()
        {
            _service = IoCFactory.Resolve<IClientService>();
        }

        /// <summary>
        /// All of the current clients.
        /// </summary>
        /// <returns>All of the current clients.</returns>
        [GET("api/clients")]
        public HttpResponseMessage GetAll()
        {
            var items = _service.List();

            var itemDto = items.Select(i => Mapper.Map(i));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        /// <summary>
        /// Client for a given unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier for a given client.</param>
        /// <returns>Client for a given unique identifier.</returns>
        [GET("api/clients/{id}")]
        public HttpResponseMessage Get([FromUri]int id)
        {
            var item = _service.Get(id);

            var itemDto = Mapper.Map(item);

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        /// <summary>
        /// Creates a new client.
        /// </summary>
        /// <param name="item">New client to create.</param>
        /// <returns>The recently created client.</returns>
        [POST("api/clients")]
        public HttpResponseMessage Post([FromBody]Client item)
        {
            if (item == null)
                return Request.CreateResponse(HttpStatusCode.OK, new Client());

            var itemDto = Mapper.Map(_service.Add(item));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        /// <summary>
        /// Updates an existing client for the given unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier for the client to update.</param>
        /// <param name="item">Client to update.</param>
        /// <returns>The recently updated client.</returns>
        [PUT("api/clients/{id}")]
        public HttpResponseMessage Put([FromUri]int id, [FromBody]Client item)
        {
            if (item == null)
                return Request.CreateResponse(HttpStatusCode.OK, new Product());

            var itemDto = Mapper.Map(_service.Update(item));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        /// <summary>
        /// Deletes a client with the given unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier for the client.</param>
        /// <returns>The recently deleted client.</returns>
        [DELETE("api/clients/{id}")]
        public HttpResponseMessage Delete([FromUri]int id)
        {
            var itemDto = Mapper.Map(_service.Delete(id));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }
    }
}
