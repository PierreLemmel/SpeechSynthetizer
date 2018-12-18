using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using Troikatorz.Speech.Data;
using Troikatorz.Speech.Settings;
using Troikatorz.Speech.Validation;
using Xunit;

namespace Troikatorz.Speech.Tests
{
    public class SpeechSettingsValidatorShould
    {
        private readonly SpeechSettingsValidator validator = new SpeechSettingsValidator();

        [Theory]
        [MemberData(nameof(ValidSettings))]
        public void Return_True_When_Input_Is_Valid(SpeechSettings settings)
        {
            ValidationResult result = validator.Validate(settings);

            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(253)]
        [InlineData(int.MinValue)]
        public void Return_False_When_Volume_Is_Not_Between_0_And_100(int volume)
        {
            SpeechSettings input = Some.ValidSettingsWithTextInputAndSpeakerOutput
                .WithVolume(volume);

            ValidationResult result = validator.Validate(input);

            Assert.False(result.IsValid);
        }

        [Theory]
        [InlineData(-11)]
        [InlineData(12)]
        [InlineData(666)]
        public void Return_False_When_Rate_Is_Not_Between_Minus10_And_10(int rate)
        {
            SpeechSettings input = Some.ValidSettingsWithFileInputAndSpeakerOutput
                .WithRate(rate);

            ValidationResult result = validator.Validate(input);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void Return_False_When_Output_Does_Not_Exist()
        {
            SpeechOutput output = (SpeechOutput)42;

            SpeechSettings input = Some.ValidSettingsWithFileInputAndSpeakerOutput
                .WithOutput(output);

            ValidationResult result = validator.Validate(input);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void Return_False_When_Both_InputText_And_InputFile_Are_Null()
        {
            SpeechSettings input = Some.SpeechSettings
                .WithoutInputFile()
                .WithoutInputText();

            ValidationResult result = validator.Validate(input);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void Return_True_When_OutputFile_Is_Null_And_Output_Is_Speaker()
        {
            SpeechSettings input = Some.SpeechSettings
                .WithInputText(Some.InputText)
                .WithSpeakerOutput()
                .WithoutOutputFile();

            ValidationResult result = validator.Validate(input);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void Return_False_When_OutputFile_Is_Null_And_Output_Is_File()
        {
            SpeechSettings input = Some.SpeechSettings
                .WithFileOutput()
                .WithoutOutputFile();

            ValidationResult result = validator.Validate(input);

            Assert.False(result.IsValid);
        }

        [Theory]
        [MemberData(nameof(InvalidPathes))]
        public void Return_False_When_OutputFile_Is_Not_A_Valid_RelativePath_And_Output_Is_File(string outputFile)
        {
            SpeechSettings input = Some.SpeechSettings
                .WithFileOutput()
                .WithOutputFile(outputFile);

            ValidationResult result = validator.Validate(input);

            Assert.False(result.IsValid);
        }

        [Theory]
        [MemberData(nameof(InvalidPathes))]
        public void Return_False_When_InputText_Is_Empty_And_InputFile_Is_Invalid(string invalidPath)
        {
            SpeechSettings input = Some.SpeechSettings
                .WithoutInputText()
                .WithOutputFile(invalidPath);

            ValidationResult result = validator.Validate(input);

            Assert.False(result.IsValid);
        }

        public static IEnumerable<object[]> ValidSettings => Some.ValidSettings.ToMemberDataSource();
        public static IEnumerable<object[]> InvalidPathes => Some.InvalidPathes.ToMemberDataSource();

        
    }
}
