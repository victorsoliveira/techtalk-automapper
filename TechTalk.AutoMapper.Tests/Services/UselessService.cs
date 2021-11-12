using System;
using Xunit.Abstractions;

namespace TechTalk.AutoMapper.Tests.Services
{
    public interface IUselessService
    {
        void MakeNothing(Type type);
    }

    public class UselessService : IUselessService
    {
        private readonly ITestOutputHelper _outputHelper;

        public UselessService(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        public void MakeNothing(Type type)
        {
            _outputHelper.WriteLine($"Making nothing at {type.Name} ...");
        }
    }
}
