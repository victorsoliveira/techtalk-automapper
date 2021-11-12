using FluentAssertions;
using FluentAssertions.Equivalency;
using System.Linq;
using TechTalk.AutoMapper.Domain.Dtos;
using TechTalk.AutoMapper.Domain.Dtos.Levers;
using TechTalk.AutoMapper.Domain.Dtos.Levers.TargetRanges;
using TechTalk.AutoMapper.Domain.Entities;
using TechTalk.AutoMapper.Domain.Entities.Levers;
using TechTalk.AutoMapper.Domain.Entities.Levers.TargetRanges;
using TechTalk.AutoMapper.Domain.Enums;

namespace TechTalk.AutoMapper.Tests.Comparators
{
    public class AgreementComparer : IEquivalencyStep
    {
        public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IEquivalencyValidator nestedValidator)
        {
            if (comparands.Subject is Agreement agreement && comparands.Expectation is AgreementDto dto)
            {
                var domainModel = agreement;
                var dtoModel = dto;

                dtoModel.Id.Should().Be(domainModel.Id.ToString());
                dtoModel.Identifier.Should().Be(domainModel.Identifier);
                dtoModel.Start.Should().Be(domainModel.CustomLevers.Min(cl => cl.Start));
                dtoModel.End.Should().Be(domainModel.CustomLevers.Max(cl => cl.End));
                dtoModel.Status.Should().Be(domainModel.Status);
                dtoModel.DocumentId.Should().Be(domainModel.Document?.Id);
                dtoModel.DocumentTitle.Should().Be(domainModel.Document?.Title);
                dtoModel.CustomLevers.Should().BeEquivalentTo(domainModel.CustomLevers, opt => opt.Using(new CustomLeverComparer()).WithStrictOrdering());

                return EquivalencyResult.AssertionCompleted;

            }
            
            return EquivalencyResult.ContinueWithNext;
        }
    }

    public class CustomLeverComparer : IEquivalencyStep
    {
        public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IEquivalencyValidator nestedValidator)
        {
            if (comparands.Subject is CustomLeverDto dto && comparands.Expectation is CustomLever agreement)
            {
                var domainModel = agreement;
                var dtoModel = dto;

                dtoModel.Id.Should().Be(domainModel.Id.ToString());
                dtoModel.Start.Should().Be(domainModel.Start);
                dtoModel.End.Should().Be(domainModel.End);
                dtoModel.TargetRanges.Should().BeEquivalentTo(domainModel.TargetRanges, opt => opt.Using(new CustomTargetRangeComparer()).WithStrictOrdering());

                return EquivalencyResult.AssertionCompleted;

            }

            return EquivalencyResult.ContinueWithNext;
        }
    }

    public class CustomTargetRangeComparer : IEquivalencyStep
    {
        public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IEquivalencyValidator nestedValidator)
        {
            if (comparands.Subject is CustomTargetRangeDto dto && comparands.Expectation is CustomTargetRange agreement)
            {
                var domainModel = agreement;
                var dtoModel = dto;

                dtoModel.Id.Should().Be(domainModel.Id.ToString());

                if (domainModel.TargetType == TargetTypeGrpc.Zero)
                {
                    dtoModel.TargetType.Should().BeNull();
                } else
                {
                    dtoModel.TargetType.Should().Be((TargetType?)(int)domainModel.TargetType);
                }
                
                dtoModel.RefundType.Should().Be(domainModel.RefundType);

                return EquivalencyResult.AssertionCompleted;
            }

            return EquivalencyResult.ContinueWithNext;
        }
    }
}
