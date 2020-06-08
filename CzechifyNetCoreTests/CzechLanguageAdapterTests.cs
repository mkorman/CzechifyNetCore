using System;
using CzechifyNetCore.Services;
using Xunit;

namespace CzechifyNetCoreTests
{
    public class CzechLanguageAdapterTests
    {
        private readonly ILanguageAdapter _adapter;

        public CzechLanguageAdapterTests()
        {
            _adapter = new CzechLanguageAdapter();
        }

        [Fact]
        public void WhenIUseCzechAdapter_ThenISeeTheRightTitle()
        {
            Assert.Equal("Czechify!", _adapter.Title);
        }

        [Theory]
        [InlineData("I am sorry", "m srry")]
        [InlineData("Hello World", "Hll wrld")]
        [InlineData("I love C#", "lv C#")]
        public void GivenALanguageWithVowels_WhenIAdapt_ThenVowelsAreGone(string input, string expectedOutput)
        {
            var output = _adapter.Adapt(input);

            Assert.Equal(expectedOutput, output, StringComparer.InvariantCultureIgnoreCase);
        }
    }
}
