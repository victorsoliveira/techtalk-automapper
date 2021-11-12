using AutoMapper;
using System;
using System.Linq;
using TechTalk.AutoMapper.Domain.Dtos;
using TechTalk.AutoMapper.Domain.Entities;
using TechTalk.AutoMapper.Tests.Services;

namespace TechTalk.AutoMapper.Tests.Resolvers
{
    public class AgreementStartResolver : IValueResolver<Agreement, AgreementDto, DateTime>
    {
        private readonly IUselessService _uselessService;

        public AgreementStartResolver(IUselessService uselessService)
        {
            _uselessService = uselessService;
        }

        public DateTime Resolve(Agreement source, AgreementDto destination, DateTime destMember, ResolutionContext context)
        {
            _uselessService.MakeNothing(GetType());
            return source.CustomLevers.Min(cl => cl.Start);
        }
    }
}
