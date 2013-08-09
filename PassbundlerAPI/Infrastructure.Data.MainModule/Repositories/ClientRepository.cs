using System;
using System.Collections.Generic;
using System.Linq;
using Domain.MainModule.Bundles;
using Infrastructure.Data.MainModule.Models;
using Infrastructure.Data.MainModule.Contexts;
using Domain.Core;
using Domain.MainModule.Entities;
using Domain.MainModule.Clients;

namespace Infrastructure.Data.MainModule.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly PassBundlerContext _context;

		public ClientRepository()
        {
            _context = new PassBundlerContext();
        }

        public Client Add(Client item)
        {
            var addedItem = _context.Clients.Add(item);

            _context.SaveChanges();

            return addedItem;
        }

        public Client Update(Client item)
        {
            var itemToUpdate = _context.Clients.FirstOrDefault(b => b.Id == item.Id);

            itemToUpdate = item;

            _context.SaveChanges();

            return itemToUpdate;
        }

        public Client Delete(int id)
        {
            var itemToDelete = _context.Clients.FirstOrDefault(b => b.Id == id);

            var deletedItem = _context.Clients.Remove(itemToDelete);

            _context.SaveChanges();

            return deletedItem;
        }

        public IEnumerable<Client> List()
        {
            var items = _context.Clients;

            return items;
        }

        public Client Get(int id)
        {
            var item = _context.Clients.ToList().FirstOrDefault(b => b.Id == id);

            return item;
        }

    }
}
