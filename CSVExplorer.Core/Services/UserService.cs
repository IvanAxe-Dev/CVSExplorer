using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CSVExplorer.Core.Domain.Entities;
using CSVExplorer.Core.RepositoryContracts;
using CSVExplorer.Core.ServiceContracts;

namespace CSVExplorer.Core.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
    }
}
