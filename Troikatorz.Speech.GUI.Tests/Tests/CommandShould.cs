using System;
using System.Windows.Input;
using Troikatorz.Speech.GUI.Data;
using Troikatorz.Speech.GUI.SampleClasses;
using Xunit;
using Xunit.Sdk;

namespace Troikatorz.Speech.GUI.Tests
{
    public class CommandShould
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

        [Fact]
        public void Raise_CanExecuteChanged_When_When_Predicate_Is_Matched()
        {
            Action<ExampleViewModel> someAction = Some.Action<ExampleViewModel>();
            Predicate<ExampleViewModel> alwaysMatched = Some.AlwaysMatchedPredicate<ExampleViewModel>();

            ICommand command = new Command<ExampleViewModel>(someAction, alwaysMatched);
            object parameter = Some.ExampleViewModel.Build();
            
            MoreAssert.Raises(
                attach: handler => command.CanExecuteChanged += handler,
                detach: handler => command.CanExecuteChanged -= handler,
                testAction: () => command.CanExecute(parameter));            
        }



        private static class MoreAssert
        {
            public static RaisedEvent Raises(Action<EventHandler> attach, Action<EventHandler> detach, Action testAction)
            {
                RaisedEvent raised = null;

                attach(OnEventRaised);
                testAction();
                detach(OnEventRaised);

                if (raised is null)
                    throw new RaisesException(typeof(EventArgs));

                return raised;

                void OnEventRaised(object sender, EventArgs e) => raised = new RaisedEvent(sender, e);
            }

            public static void DoesNotThrow(Action action) => DoesNotThrow<Exception>(action);
            public static void DoesNotThrow<TException>(Action action)
                where TException : Exception
            {
                try
                {
                    action?.Invoke();
                }
                catch (TException tex)
                {
                    throw new DoesNotThrowException(tex, typeof(TException));
                }
                catch { }
            }

            public class DoesNotThrowException : AssertActualExpectedException
            {
                public DoesNotThrowException(Exception thrown) : this(thrown, typeof(Exception)) { }
                public DoesNotThrowException(Exception thrown, Type scannedType) : base(
                    null,
                    thrown,
                    $"The code threw an unexpected {scannedType.Name} (exception type: {thrown.GetType().Name})",
                    $"No {scannedType.Name}",
                    thrown.GetType().Name)
                {
                    Exception = thrown;
                }

                public Exception Exception { get; }               
            }

            public sealed class RaisedEvent
            {
                internal RaisedEvent(object sender, EventArgs eventArgs)
                {
                    Sender = sender;
                    EventArgs = eventArgs;
                }

                public object Sender { get; }
                public EventArgs EventArgs { get; }
            }
        }
    }
}
