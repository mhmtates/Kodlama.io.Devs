﻿using Application.Features.Technologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.Technologys.Queries.GetByIdTechnology
{
    public class GetByIdTechnologyQuery : IRequest<TechnologyGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdTechnologyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, TechnologyGetByIdDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;

            public GetByIdTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;

            }

            public async Task<TechnologyGetByIdDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
            {
                Technology? technology = await _technologyRepository.GetAsync(b => b.Id == request.Id);
                TechnologyGetByIdDto TechnologyGetByIdDto = _mapper.Map<TechnologyGetByIdDto>(technology);
                return TechnologyGetByIdDto;
            }
        }
    }
}

