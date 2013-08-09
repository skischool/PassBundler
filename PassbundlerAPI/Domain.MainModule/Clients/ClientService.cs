using System;
using System.Collections.Generic;
using System.Linq;
using Domain.MainModule.Bundles;
using Domain.MainModule.Entities;

namespace Domain.MainModule.Clients
{
    public class ClientService : IClientService
    {
    	readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public Client Add(Client item)
        {
            return _repository.Add(item);
        }

        public Client Update(Client item)
        {
            return _repository.Update(item);
        }

        public Client Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Client Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Client> List()
        {
            return _repository.List();
        }
    }
}
