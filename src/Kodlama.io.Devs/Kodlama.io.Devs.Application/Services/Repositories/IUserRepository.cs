using Core.Persistence.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories
{
    public interface IUserRepository: IAsyncRepository<User>, IRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
