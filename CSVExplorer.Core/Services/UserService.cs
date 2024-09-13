using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CSVExplorer.Core.Domain.Entities;
using CSVExplorer.Core.DTOs;
using CSVExplorer.Core.RepositoryContracts;
using CSVExplorer.Core.ServiceContracts;

namespace CSVExplorer.Core.Services
{
    public class UserService : Service<User>, IUserService
    {
        private IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task InsertRangeAsync(ICollection<UserDto> users)
        {
            await _repository.PostManyAsync(_mapper.Map<List<User>>(users));
            await _repository.SaveChangesAsync();
        }
    }
}
