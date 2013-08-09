using System;
using System.Collections.Generic;
using System.Linq;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Bundles
{
    public class BundleService : IBundleService
    {
    	readonly IBundleRepository _bundleRepository;

        public BundleService(IBundleRepository bundleRepository)
        {
            _bundleRepository = bundleRepository;
        }

        public Bundle AddBundle(Bundle bundle)
        {
            return _bundleRepository.AddBundle(bundle);
        }

        public Bundle UpdateBundle(Bundle bundle)
        {
            return _bundleRepository.UpdateBundle(bundle);
        }

        public Bundle DeleteBundle(int id)
        {
            return _bundleRepository.DeleteBundle(id);
        }

        public Bundle GetBundle(int id)
        {
            return _bundleRepository.GetBundle(id);
        }

        public IEnumerable<Bundle> GetBundles(Bundle bundle)
        {
            return _bundleRepository.GetBundles(bundle);
        }
    }
}
