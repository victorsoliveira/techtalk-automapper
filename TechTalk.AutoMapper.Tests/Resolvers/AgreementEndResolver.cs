using AutoMapper;
using System;
using System.Linq;
using TechTalk.AutoMapper.Domain.Dtos;
using TechTalk.AutoMapper.Domain.Entities;
using TechTalk.AutoMapper.Tests.Services;

namespace TechTalk.AutoMapper.Tests.Resolvers
{
    public class AgreementEndResolver : IValueResolver<Agreement, AgreementDto, DateTime>
    {
        private readonly IUselessService _uselessService;

        public AgreementEndResolver(IUselessService uselessService)
        {
            _uselessService = uselessService;
        }

        public DateTime Resolve(Agreement source, AgreementDto destination, DateTime destMember, ResolutionContext context)
        {
            _uselessService.MakeNothing(GetType());
            return source.CustomLevers.Max(cl => cl.End);
        }
    }
}
