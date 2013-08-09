using System.Collections.Generic;
using Domain.Core;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Clients
{
    public interface IClientRepository
    {
        Client Add(Client item);

        Client Update(Client item);

        Client Delete(int id);

        IEnumerable<Client> List();

        Client Get(int id);
    }
}
