using System;
using System.Collections.Generic;
using TechTalk.AutoMapper.Domain.Dtos.Levers.TargetRanges;

namespace TechTalk.AutoMapper.Domain.Dtos.Levers
{
    public class CustomLeverDto : EntityDto
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public IEnumerable<CustomTargetRangeDto> TargetRanges { get; set; } = new List<CustomTargetRangeDto>();
    }
}
