using System;
using System.Collections.Generic;
using TechTalk.AutoMapper.Domain.Dtos.Levers;
using TechTalk.AutoMapper.Domain.Enums;

namespace TechTalk.AutoMapper.Domain.Dtos
{
    public class AgreementDto : EntityDto
    {
        public string Identifier { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public AgreementStatus Status { get; set; }

        // Flatting Document Info With Mapping Convention-Based
        public Guid? DocumentId { get; set; }
        public string DocumentTitle { get; set; }

        public IEnumerable<CustomLeverDto> CustomLevers { get; set; } = new List<CustomLeverDto>();
    }
}
