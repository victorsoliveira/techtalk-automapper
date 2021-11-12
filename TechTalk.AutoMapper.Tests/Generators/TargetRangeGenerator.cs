using Bogus;
using System;
using System.Collections.Generic;
using TechTalk.AutoMapper.Domain.Entities.Levers.TargetRanges;
using TechTalk.AutoMapper.Domain.Enums;

namespace TechTalk.AutoMapper.Tests.Generators
{
    public static class TargetRangeGenerator
    {
        public static IEnumerable<CustomTargetRange> GenerateCustomTargetRanges(int quantity = 3)
        {
            return new Faker<CustomTargetRange>("pt_BR")
                         .RuleFor(c => c.Id, f => Guid.NewGuid())
                         .RuleFor(c => c.TargetType, f => f.PickRandom<TargetTypeGrpc>())
                         .RuleFor(c => c.TargetValue, f => f.PickRandom(new decimal?[] { 0, null, 10, null }))
                         .RuleFor(c => c.RefundType, f => f.PickRandom(new RefundType?[] { RefundType.HL, null, RefundType.ROB, null, RefundType.ROL, null }))
                         .Generate(quantity);
        }
    }
}
