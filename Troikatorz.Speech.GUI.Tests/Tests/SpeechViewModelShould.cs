using AutoFixture;
using AutoFixture.Xunit2;
using System;
using Troikatorz.Speech.Data.Model;
using Troikatorz.Speech.GUI.ViewModel;
using Xunit;

namespace Troikatorz.Speech.GUI.Tests
{
    public class SpeechViewModelShould : ViewModelFacts<SpeechViewModel, SpeechModel>
    {
        private readonly Fixture fixture = new Fixture();

        [Fact]
        public void Constructor_Should_Throw_If_Provided_Speech_Is_Null()
        {
            SpeechModel nullModel = null;

            Assert.Throws<ArgumentNullException>(() => new SpeechViewModel(nullModel));
        }
    }
}
