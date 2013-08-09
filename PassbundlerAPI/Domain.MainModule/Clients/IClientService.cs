using System.Collections.Generic;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Clients
{
    public interface IClientService
    {
        Client Add(Client item);

        Client Update(Client item);

        Client Delete(int id);

        Client Get(int id);

        IEnumerable<Client> List();
    }
}
