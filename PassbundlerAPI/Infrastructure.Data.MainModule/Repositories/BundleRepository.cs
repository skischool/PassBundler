using System;
using System.Collections.Generic;
using System.Linq;
using Domain.MainModule.Bundles;
using Infrastructure.Data.MainModule.Models;
using Infrastructure.Data.MainModule.Contexts;
using Domain.Core;
using Domain.MainModule.Entities;

namespace Infrastructure.Data.MainModule.Repositories
{
    public class BundleRepository : IBundleRepository
    {
        private readonly PassBundlerContext _passBundlerContext;

		public BundleRepository()
        {
            _passBundlerContext = new PassBundlerContext();
        }

        public Bundle AddBundle(Bundle bundle)
        {
            var addedBundle = _passBundlerContext.Bundles.Add(bundle);

            _passBundlerContext.SaveChanges();

            return addedBundle;
        }

        public Bundle UpdateBundle(Bundle bundle)
        {
            var bundleToUpdate = _passBundlerContext.Bundles.FirstOrDefault(b => b.Id == bundle.Id);

            bundleToUpdate = bundle;

            _passBundlerContext.SaveChanges();

            return bundleToUpdate;
        }

        public Bundle DeleteBundle(int id)
        {
            var bundleToDelete = _passBundlerContext.Bundles.FirstOrDefault(b => b.Id == id);

            var deletedBundle = _passBundlerContext.Bundles.Remove(bundleToDelete);

            _passBundlerContext.SaveChanges();

            return deletedBundle;
        }

        public IEnumerable<Bundle> GetBundles(Bundle bundle)
        {
            var bundles = _passBundlerContext.Bundles;

            return bundles;
        }

        public Bundle GetBundle(int id)
        {
            var bundle = _passBundlerContext.Bundles.ToList().FirstOrDefault(b => b.Id == id);

            return bundle;
        }
    }
}
