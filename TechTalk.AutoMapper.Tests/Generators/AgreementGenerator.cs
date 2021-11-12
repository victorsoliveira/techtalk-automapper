using Bogus;
using System;
using System.Collections.Generic;
using TechTalk.AutoMapper.Domain.Entities;
using TechTalk.AutoMapper.Domain.Entities.Levers;

namespace TechTalk.AutoMapper.Tests.Generators
{
    public static class AgreementGenerator
    {
        public static Agreement Generate(IEnumerable<CustomLever> customLevers = null)
        {
            var agreement = new Faker<Agreement>("pt_BR")
                         .RuleFor(c => c.Id, f => Guid.NewGuid())
                         .RuleFor(c => c.Identifier, f => f.Random.Word())
                         .Generate();

            agreement.SetCustomLevers(customLevers ?? LeverGenerator.GenerateCustomLevers());

            return agreement;
        }
    }
}
