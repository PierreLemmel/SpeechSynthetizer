using Troikatorz.Speech.GUI.SampleClasses;

namespace Troikatorz.Speech.GUI.Builders
{
    internal class ExampleViewModelBuilder : Builder<ExampleViewModel>
    {
        private bool isValid = default;

        public ExampleViewModelBuilder WhichIsValid()
        {
            isValid = true;
            return this;
        }

        public ExampleViewModelBuilder WhichIsNotValid()
        {
            isValid = false;
            return this;
        }

        public override ExampleViewModel Build() => new ExampleViewModel
        {
            IsValid = isValid
        };
    }
}
