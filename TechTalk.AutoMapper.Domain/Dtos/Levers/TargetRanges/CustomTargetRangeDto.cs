using TechTalk.AutoMapper.Domain.Enums;

namespace TechTalk.AutoMapper.Domain.Dtos.Levers.TargetRanges
{
    public class CustomTargetRangeDto : EntityDto
    {
        public TargetType? TargetType { get; set; }
        public decimal? TargetValue { get; set; }
        public RefundType? RefundType { get; set; }
    }
}