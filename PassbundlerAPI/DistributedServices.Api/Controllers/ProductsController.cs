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
using Domain.MainModule.Products;

namespace DistributedServices.Api.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService _service;

        public ProductsController()
        {
            _service = IoCFactory.Resolve<IProductService>();
        }

        /// <summary>
        /// All of the products associated with a given bundle.
        /// </summary>
        /// <param name="bundleId">Unique identifer for a given bundle.</param>
        /// <returns>All products for a bundle.</returns>
        [GET("api/bundles/{bundleId}/products")]
        public HttpResponseMessage GetAll([FromUri]int bundleId)
        {
            var items = _service.List(new Product() { BundleId = bundleId });

            var itemDto = items.Select(i => Mapper.Map(i));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        /// <summary>
        /// A product contained within a given bundle.
        /// </summary>
        /// <param name="bundleId">Unique identifier for a bundle.</param>
        /// <param name="id">Unique identifier for a product.</param>
        /// <returns>Product from a given bundle.</returns>
        [GET("api/bundles/{bundleId}/products/{id}")]
        public HttpResponseMessage Get([FromUri]int bundleId, [FromUri]int id)
        {
            var item = _service.Get(id);

            var itemDto = Mapper.Map(item);

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        /// <summary>
        /// Creates a new product in a given bundle.
        /// </summary>
        /// <param name="bundleId">Unique identifier for a bundle.</param>
        /// <param name="item">New product to create in the given bundle.</param>
        /// <returns>The recently created product.</returns>
        [POST("api/bundles/{bundleId}/products/{id}")]
        public HttpResponseMessage Post([FromUri]int bundleId, [FromBody]Product item)
        {
            if (item == null)
                return Request.CreateResponse(HttpStatusCode.OK, new Product());

            item.BundleId = bundleId;

            var itemDto = Mapper.Map(_service.Add(item));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        /// <summary>
        /// Updates an existing product in a given bundle.
        /// </summary>
        /// <param name="bundleId">Unique identifier for a bundle.</param>
        /// <param name="id">Unique identifier for a product.</param>
        /// <param name="item">Product to update in the given bundle.</param>
        /// <returns>The recently updated product.</returns>
        [PUT("api/bundles/{bundleId}/products/{id}")]
        public HttpResponseMessage Put([FromUri]int bundleId, [FromUri]int id, [FromBody]Product item)
        {
            if (item == null)
                return Request.CreateResponse(HttpStatusCode.OK, new Product());

            item.BundleId = bundleId;

            var itemDto = Mapper.Map(_service.Update(item));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }

        /// <summary>
        /// Deletes an existing product in a given bundle.
        /// </summary>
        /// <param name="bundleId">Unique identifier for a bundle.</param>
        /// <param name="id">Unique identifier for a product.</param>
        /// <returns>The recently deleted product.</returns>
        [DELETE("api/bundles/{bundleId}/products/{id}")]
        public HttpResponseMessage Delete([FromUri]int bundleId, [FromUri]int id)
        {
            var itemDto = Mapper.Map(_service.Delete(id));

            return Request.CreateResponse(HttpStatusCode.OK, itemDto);
        }
    }
}
