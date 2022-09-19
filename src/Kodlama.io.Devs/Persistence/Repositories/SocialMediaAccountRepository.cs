using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class SocialMediaAccountRepository : EfRepositoryBase<SocialMediaAccount, BaseDbContext>, ISocialMediaAccountRepository
    {
        public SocialMediaAccountRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
