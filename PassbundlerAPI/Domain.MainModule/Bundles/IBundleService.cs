using System.Collections.Generic;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Bundles
{
    public interface IBundleService
    {
        Bundle AddBundle(Bundle bundle);

        Bundle UpdateBundle(Bundle bundle);

        Bundle DeleteBundle(int id);

        Bundle GetBundle(int id);

        IEnumerable<Bundle> GetBundles(Bundle bundle);
    }
}
