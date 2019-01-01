using System;
using System.Windows.Input;
using Troikatorz.Speech.GUI.Data;
using Troikatorz.Speech.GUI.SampleClasses;
using Troikatorz.XUnit;
using Xunit;
using Xunit.Sdk;

namespace Troikatorz.Speech.GUI.Tests
{
    public class CommandFacts
    {
        [Fact]
        public void Constructor_Should_Throw_Argument_Null_Exception_When_Execute_Is_Null()
        {
            Action<ExampleViewModel> nullExecute = null;
            Predicate<ExampleViewModel> someWhenPredicate = Some.Predicate<ExampleViewModel>();

            Assert.Throws<ArgumentNullException>(
                () => new Command<ExampleViewModel>(nullExecute, someWhenPredicate));
        }

        [Fact]
        public void Constructor_Should_Not_Throw_When_When_Is_Null()
        {
            Action<ExampleViewModel> someAction = Some.Action<ExampleViewModel>();
            Predicate<ExampleViewModel> nullWhenPredicate = null;

            MoreAssert.DoesNotThrow(
                () => new Command<ExampleViewModel>(someAction, nullWhenPredicate));
        }

        [Fact]
        public void CanExecute_Shoud_Return_True_When_When_Predicate_Is_Not_Provided()
        {
            Action<ExampleViewModel> someAction = Some.Action<ExampleViewModel>();
            Predicate<ExampleViewModel> nullWhenPredicate = null;

            ICommand command = new Command<ExampleViewModel>(someAction, nullWhenPredicate);
            ExampleViewModel someViewModel = Some.ExampleViewModel;

            bool canExecute = command.CanExecute(someViewModel);

            Assert.True(canExecute);
        }
    }
}
