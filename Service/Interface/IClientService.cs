using Data.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public  interface IClientService
    {
        Task<List<ClientModel>?> GetClients();
        Task<Client> AddClient(CreateClientModel createClientModel);
        Task<ClientModel> GetClient(int Id);
        Task<List<Client>?> ExportClientsInJson();
        Task<Client?> UpdateClient(int Id, UpdateClientModel updateClientModel);

    }
}
