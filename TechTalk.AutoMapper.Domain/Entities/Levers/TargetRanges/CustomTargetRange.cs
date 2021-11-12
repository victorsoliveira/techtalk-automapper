using TechTalk.AutoMapper.Domain.Enums;

namespace TechTalk.AutoMapper.Domain.Entities.Levers.TargetRanges
{
    public class CustomTargetRange : Entity
    {
        public TargetTypeGrpc TargetType { get; protected set; }
        public decimal? TargetValue { get; protected set; }
        public RefundType? RefundType { get; protected set; }

        public void SetTargetType(TargetTypeGrpc targetType)
        {
            TargetType = targetType;
        }
    }
}