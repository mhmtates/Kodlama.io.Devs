using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IUserProfileRepository:IAsyncRepository<UserProfile>,IRepository<UserProfile>
    {
        

    }
}
