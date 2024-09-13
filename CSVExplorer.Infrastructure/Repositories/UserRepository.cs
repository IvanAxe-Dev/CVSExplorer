using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVExplorer.Core.Domain.Entities;
using CSVExplorer.Core.RepositoryContracts;

namespace CSVExplorer.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(CSVContext dataContext) : base(dataContext)
        {
        }

        public async Task PostManyAsync(ICollection<User> users)
        {
            if (!users.Any())
                throw new ArgumentException("The user list cannot be empty.", nameof(users));

            await dbSet.AddRangeAsync(users);
        }
    }
}
