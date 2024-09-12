using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVExplorer.Core.Domain.Entities;
using CSVExplorer.Core.RepositoryContracts;

namespace CSVExplorer.Core.ServiceContracts
{
    public interface IUserService : IService<User>
    {
    }
}
