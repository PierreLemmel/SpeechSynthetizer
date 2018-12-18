using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Troikatorz.Speech.Data;
using Troikatorz.Speech.Settings;
using Xunit;

namespace Troikatorz.Speech.Tests
{
    public class SpeechSettingsValidatorShould
    {
        private readonly SpeechSettingsValidator validator = new SpeechSettingsValidator();

        [Theory]
        [MemberData()]
        public void Not_Throw(SpeechSettings settings)
        {
            ValidationResult result = validator.Validate(settings);

            Assert.True(result.IsValid);
        }

        public static IEnumerable<object[]> ValidSettings
        {
            get
            {
                yield return new [] { Some.ValidSettings.}
            }
        }
    }
}
