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

namespace DistributedServices.Api.Controllers
{
    public class BundlesController : ApiController
    {
        private readonly IBundleService _bundleService;

        public BundlesController()
        {
            _bundleService = IoCFactory.Resolve<IBundleService>();
        }

        /// <summary>
        /// Returns a bundle of products for the provided Id.
        /// </summary>
        /// <param name="id">Unique identifier for a given Bundle.</param>
        /// <returns>Bundle of products.</returns>
        [GET("api/bundles/{id}")]
        public HttpResponseMessage Get([FromUri]int id)
        {
            var bundle = _bundleService.GetBundle(id);

            var bundleDto = Mapper.Map(bundle);

            return Request.CreateResponse(HttpStatusCode.OK, bundleDto);
        }

        /// <summary>
        /// Creates a new bundle.
        /// </summary>
        /// <param name="bundle">New bundle to create.</param>
        /// <returns>The recently created bundle.</returns>
        [POST("api/bundles")]
        public HttpResponseMessage Post([FromBody]Bundle bundle)
        {
            if (bundle == null)
                return Request.CreateResponse(HttpStatusCode.OK, new Bundle());

            var addBundleDto = Mapper.Map(_bundleService.AddBundle(bundle));

            return Request.CreateResponse(HttpStatusCode.OK, addBundleDto);
        }

        /// <summary>
        /// Updates the provided bundle.
        /// </summary>
        /// <param name="id">Unique identifier of the bundle to update.</param>
        /// <param name="bundle">New bundle to update the existing bundle.</param>
        /// <returns>The bundle which has been updated.</returns>
        [PUT("api/bundles/{id}")]
        public HttpResponseMessage Put([FromUri]int id, [FromBody]Bundle bundle)
        {
            if (bundle == null)
                return Request.CreateResponse(HttpStatusCode.OK, new Bundle());

            var updateBundleResponse = Mapper.Map(_bundleService.UpdateBundle(bundle));

            return Request.CreateResponse(HttpStatusCode.OK, updateBundleResponse);
        }

        /// <summary>
        /// Deletes the bundle with the provided unique identifier.
        /// </summary>
        /// <param name="id">Unique identifier of the bundle to delete.</param>
        /// <returns>The bundle which has been deleted.</returns>
        [DELETE("api/bundles/{id}")]
        public HttpResponseMessage Delete([FromUri]int id)
        {
            var deleteBundleRequest = new Bundle();

            var deleteBundleDto = Mapper.Map(_bundleService.DeleteBundle(id));

            return Request.CreateResponse(HttpStatusCode.OK, deleteBundleDto);
        }
    }
}
