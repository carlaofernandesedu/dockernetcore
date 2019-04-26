﻿using DockerSQL.Domain.Models;
using System.Threading.Tasks;

namespace DockerSQL.Domain.Abstractions.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(int clientId);

        Task AddAsync(Client client);
        Task UpdateAsync(int clientId, Client client);
        Task RemoveAsync(Client client);
        Task SaveChangesAsync();
    }
}
