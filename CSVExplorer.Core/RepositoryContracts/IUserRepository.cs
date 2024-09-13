using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVExplorer.Core.Domain.Entities;
using CSVExplorer.Core.DTOs;

namespace CSVExplorer.Core.RepositoryContracts
{
    public interface IUserRepository : IRepository<User>
    {
        Task PostManyAsync(ICollection<User> users);
    }
}
