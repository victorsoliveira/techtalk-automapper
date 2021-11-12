using Bogus;
using System;
using System.Collections.Generic;
using TechTalk.AutoMapper.Domain.Entities.Levers;
using TechTalk.AutoMapper.Domain.Entities.Levers.TargetRanges;

namespace TechTalk.AutoMapper.Tests.Generators
{
    public static class LeverGenerator
    {
        public static IEnumerable<CustomLever> GenerateCustomLevers(IEnumerable<CustomTargetRange> customTargetRanges = null, int quantity = 2)
        {
            var customLevers = new Faker<CustomLever>("pt_BR")
                       .RuleFor(c => c.Id, f => Guid.NewGuid())
                       .RuleFor(c => c.Start, f => f.Date.Past(refDate: DateTime.Now, yearsToGoBack: 0))
                       .RuleFor(c => c.End, f => f.Date.Future(refDate: DateTime.Now, yearsToGoForward: 0))
                       .Generate(quantity);

            foreach (var customLever in customLevers)
                customLever.SetTargetRanges(customTargetRanges ?? TargetRangeGenerator.GenerateCustomTargetRanges());

            return customLevers;
        }
    }
}
