using System;
using Xunit.Sdk;

namespace Troikatorz.XUnit
{
    public static class MoreAssert
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
