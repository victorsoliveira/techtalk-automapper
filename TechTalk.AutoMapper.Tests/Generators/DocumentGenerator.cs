using Bogus;
using System;
using TechTalk.AutoMapper.Domain.ValueObjects;

namespace TechTalk.AutoMapper.Tests.Generators
{
    public static class DocumentGenerator
    {
        public static Document Generate()
        {
            return new Faker<Document>("pt_BR")
                        .RuleFor(r => r.Id, Guid.NewGuid())
                        .RuleFor(r => r.Title, r => r.Company.CompanyName())
                        .Generate();
        }
    }
}
