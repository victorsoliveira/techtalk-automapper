using System.Collections.Generic;
using TechTalk.AutoMapper.Domain.Entities.Levers;
using TechTalk.AutoMapper.Domain.Enums;
using TechTalk.AutoMapper.Domain.ValueObjects;

namespace TechTalk.AutoMapper.Domain.Entities
{
    public class Agreement : Entity
    {
        public string Identifier { get; protected set; }
        public Document Document { get; protected set; }
        public AgreementStatus Status { get; protected set; }
        public IEnumerable<CustomLever> CustomLevers { get; protected set; } = new List<CustomLever>();

        public void SetIdentifier(string identifier)
        {
            Identifier = identifier;
        }

        public void SetDocument(Document document)
        {
            Document = document;
        }

        public void SetStatus(AgreementStatus status)
        {
            Status = status;
        }

        public void SetCustomLevers(IEnumerable<CustomLever> customLevers)
        {
            CustomLevers = customLevers;
        }
    }
}
