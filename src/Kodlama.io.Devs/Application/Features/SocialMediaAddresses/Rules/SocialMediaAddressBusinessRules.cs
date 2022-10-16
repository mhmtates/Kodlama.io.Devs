using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaAddresses.Rules
{
    public class SocialMediaAddressBusinessRules
    {
        private readonly ISocialMediaAddressRepository _socialMediaAddressRepository;

        public SocialMediaAddressBusinessRules(ISocialMediaAddressRepository socialMediaAddressRepository)
        {
            _socialMediaAddressRepository = socialMediaAddressRepository;
        }

        public async Task  SocialMediaAddressUrlCannotBeDuplicatedWhenInserted(string url)
        {
            IPaginate<SocialMediaAddress> result = await _socialMediaAddressRepository.GetListAsync(o => o.Url == url);
            if (result.Items.Any()) throw new BusinessException("Url already exists.");

        }

        public void SocialMediaAddressShouldExistWhenRequested(SocialMediaAddress socialMediaAddress)
        {
            if (socialMediaAddress == null) throw new BusinessException("Requested socialmediaadress does not exist.");

        }
    }
}
