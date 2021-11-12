using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.AutoMapper.Domain.Dtos;
using TechTalk.AutoMapper.Domain.Entities;
using TechTalk.AutoMapper.Tests.Comparators;
using TechTalk.AutoMapper.Tests.Generators;
using TechTalk.AutoMapper.Tests.Resolvers;
using TechTalk.AutoMapper.Tests.Services;
using Xunit;
using Xunit.Abstractions;

namespace TechTalk.AutoMapper.Tests
{
    [Trait("TechTalk", "AutoMapper")]
    public class AutoMapperTests
    {
        readonly IMapper _mapper;

        public AutoMapperTests(ITestOutputHelper outputHelper) {

            var services = new ServiceCollection();

            services.AddSingleton<ITestOutputHelper>(outputHelper);
            services.AddSingleton<IUselessService, UselessService>();

            services.AddSingleton(typeof(AgreementStartResolver));
            services.AddSingleton(typeof(AgreementEndResolver));

            var provider = services.BuildServiceProvider();

            var config = new MapperConfiguration(cfg => {

                cfg.ConstructServicesUsing(provider.GetService);
                cfg.AddMaps(GetType().Assembly);

            });

            _mapper = config.CreateMapper();
        }

        [Fact(DisplayName = "AutoMapper - 1. Configuration Is Valid ?")]
        public void AutoMapper_ConfigurationIsValid()
        {
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Fact(DisplayName = "AutoMapper - 2. Mapping Working")]
        public void AutoMapper_Mapping()
        {
            //Arrange
            var agreement = AgreementGenerator.Generate();
 
            //Act
            var agreementDto = _mapper.Map<AgreementDto>(agreement);

            //Assert
            agreement.Should().BeEquivalentTo(agreementDto, opt => opt.Using(new AgreementComparer()).WithStrictOrdering());        
        }

        [Fact(DisplayName = "AutoMapper - 3. Mapping Flatting Document Info")]
        public void AutoMapper_MappingWithDocumentInfoConventionBased()
        {
            //Arrange
            var document = DocumentGenerator.Generate();
            var agreement = AgreementGenerator.Generate();

            agreement.SetDocument(document);

            //Act
            var agreementDto = _mapper.Map<AgreementDto>(agreement);

            //Assert
            agreement.Document.Should().NotBeNull();
            agreementDto.DocumentId.Should().Be(agreement.Document.Id);
            agreementDto.DocumentTitle.Should().Be(agreement.Document.Title);
        }

        [Fact(DisplayName = "AutoMapper - 4. Mapping Matching Condition")]
        public void AutoMapper_MappingMatchingCondition()
        {
            //Arrange
            var agreement = AgreementGenerator.Generate();

            //Act
            var agreementDto = _mapper.Map<AgreementDto>(agreement);

            //Assert
            agreement.Document.Should().BeNull();
            agreementDto.DocumentId.Should().BeNull();
            agreementDto.DocumentTitle.Should().BeNull();
        }

        [Fact(DisplayName = "AutoMapper - 5. Reverse Mapping")]
        public void AutoMapper_ReverseMapping()
        {
            //Arrange
            var document = DocumentGenerator.Generate();
            var agreement = AgreementGenerator.Generate();

            agreement.SetDocument(document);

            var agreementDto = _mapper.Map<AgreementDto>(agreement);

            //Act
            var newAgreement = _mapper.Map<Agreement>(agreementDto);

            //Assert
            newAgreement.Document.Should().NotBeNull();
            newAgreement.Document.Id.Should().Be(agreementDto.DocumentId.Value);
            newAgreement.Document.Title.Should().Be(agreementDto.DocumentTitle);
        }

        [Fact(DisplayName = "AutoMapper - 6. Reverse Mapping Matching PreCondition")]
        public void AutoMapper_ReverseMappingMatchingCondition()
        {
            //Arrange
            var agreement = AgreementGenerator.Generate();
            var agreementDto = _mapper.Map<AgreementDto>(agreement);

            //Act
            var newAgreement = _mapper.Map<Agreement>(agreementDto);

            //Assert
            newAgreement.Document.Should().BeNull();
            agreementDto.DocumentId.Should().BeNull();
            agreementDto.DocumentTitle.Should().BeNull();
        }
    }
}
