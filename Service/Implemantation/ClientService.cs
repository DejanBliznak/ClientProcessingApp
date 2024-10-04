using Data.Contex;
using Data.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implemantation
{
    public class ClientService : IClientService
    {

        public readonly ApplicationDbContext _context;
        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ClientModel>?> GetClients()
        {
            var clients = await _context.Clients
                        .Include(c => c.Addresses)
                        .ToListAsync();

            if (clients == null)
            {
                return null;
            }
            var clientModels = clients.Select(x => new ClientModel()
            {
                Id = x.Id,
                Name = x.Name,
                BirthDate = x.BirthDate,
                Addresses = x.Addresses.Select(y => new AddressModel()
                {
                    Id = y.Id,
                    AddressLine = y.AddressLine,
                    Type = y.Type
                }).ToList()
            }).ToList();
            return clientModels;
        }



        public async Task<Client> AddClient(CreateClientModel createClientModel)
        {
            var client = new Client()
            {
                Name = createClientModel.Name,
                BirthDate = (DateTime)createClientModel.BirthDate,

            };

            client.Addresses = createClientModel.Addresses.Select(x => new Address()
            {
                AddressLine = x.AddressLine,
                ClientID = client.Id,
                Type = x.Type,
            }).ToList();

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return client;
        }

        public async Task<ClientModel?> GetClient(int Id)
        {
            var client = await _context.Clients
                         .Include(c => c.Addresses)
                         .FirstOrDefaultAsync(c => c.Id == Id);

            if (client == null)
            {
                return null;
            }
            var clientModel = new ClientModel()
            {
                Id = Id,
                Name = client.Name,
                BirthDate = client.BirthDate,
                Addresses = client.Addresses.Select(x => new AddressModel()
                {
                    Id = x.Id,
                    AddressLine = x.AddressLine,
                    Type = x.Type
                }).ToList()
            };
            return clientModel;
        }

        public async Task<List<Client>?> ExportClientsInJson()
        {
            var clients = await _context.Clients
                                 .Include(c => c.Addresses)
                                 .OrderBy(c => c.Name)
                                 .ThenBy(c => c.BirthDate)
                                 .ToListAsync();

            return clients;

        }

        public async Task<Client?> UpdateClient(int Id, UpdateClientModel updateClientModel)
        {
            var client = await _context.Clients
                        .Include(c => c.Addresses)
                        .FirstOrDefaultAsync(c => c.Id == Id);

            if (client == null)
            {
                return null;
            }

            client.Name = updateClientModel.Name;
            client.BirthDate = (DateTime)updateClientModel.BirthDate;

            foreach (var address in updateClientModel.Addresses)
            {
                client.Addresses.Where(x => x.Id == address.Id).SingleOrDefault().AddressLine = address.AddressLine;
            }

             _context.Clients.Update(client);
            await _context.SaveChangesAsync();
            return client;
        }
    }
}

