using System;
using System.Collections.Generic;
using TechTalk.AutoMapper.Domain.Entities.Levers.TargetRanges;

namespace TechTalk.AutoMapper.Domain.Entities.Levers
{
    public class CustomLever : Entity
    {
        public DateTime Start { get; protected set; }
        public DateTime End { get; protected set; }
        public IEnumerable<CustomTargetRange> TargetRanges { get; protected set; } = new List<CustomTargetRange>();

        public void SetTargetRanges(IEnumerable<CustomTargetRange> customTargetRanges)
        {
            TargetRanges = customTargetRanges;
        }
    }
}
