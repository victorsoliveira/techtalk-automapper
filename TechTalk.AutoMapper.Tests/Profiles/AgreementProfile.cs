using AutoMapper;
using TechTalk.AutoMapper.Domain.Dtos;
using TechTalk.AutoMapper.Domain.Dtos.Levers;
using TechTalk.AutoMapper.Domain.Dtos.Levers.TargetRanges;
using TechTalk.AutoMapper.Domain.Entities;
using TechTalk.AutoMapper.Domain.Entities.Levers;
using TechTalk.AutoMapper.Domain.Entities.Levers.TargetRanges;
using TechTalk.AutoMapper.Domain.Enums;
using TechTalk.AutoMapper.Domain.ValueObjects;
using TechTalk.AutoMapper.Tests.Resolvers;

namespace TechTalk.AutoMapper.Tests.Profiles
{
    public class AgreementProfile : Profile
    {
        public AgreementProfile()
        {
            CreateMap<CustomTargetRange, CustomTargetRangeDto>()
                .ForMember(m => m.TargetType, opt =>
                {
                    opt.Condition(c => c.TargetType != TargetTypeGrpc.Zero);
                    opt.MapFrom(m => (TargetType?)(int)m.TargetType);
                })
                .ReverseMap();

            CreateMap<CustomLever, CustomLeverDto>()
                .ReverseMap();

            CreateMap<Agreement, AgreementDto>()
                .ForMember(m => m.Start, opt => opt.MapFrom<AgreementStartResolver>())
                .ForMember(m => m.End, opt => opt.MapFrom<AgreementEndResolver>())
                .ReverseMap()
                .ForMember(m => m.Document, opt =>
                {
                    opt.PreCondition(c => !c.DocumentId.HasValue);
                    opt.Ignore();
                })
               .ForMember(m => m.Document, opt =>
               {
                   opt.PreCondition(c => c.DocumentId.HasValue);
                   opt.MapFrom(m => new Document { Id = m.DocumentId.Value, Title = m.DocumentTitle });
               });
        }
    }
}
