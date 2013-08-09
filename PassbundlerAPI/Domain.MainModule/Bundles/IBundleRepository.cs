using System.Collections.Generic;
using Domain.Core;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Bundles
{
    public interface IBundleRepository
    {
        Bundle AddBundle(Bundle bundle);

        Bundle UpdateBundle(Bundle bundle);

        Bundle DeleteBundle(int id);

        IEnumerable<Bundle> GetBundles(Bundle bundle);

        Bundle GetBundle(int id);
    }
}
