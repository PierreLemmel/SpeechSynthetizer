using AutoFixture.Idioms;
using AutoFixture.Kernel;
using System;
using System.ComponentModel;
using System.Reflection;

namespace Troikatorz.Speech.Tests.Assertions
{
    public class PropertyChangedAssertion : IdiomaticAssertion
    {
        private readonly ISpecimenBuilder builder;

        public PropertyChangedAssertion(ISpecimenBuilder builder)
        {
            this.builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public override void Verify(PropertyInfo property)
        {
            if (property is null) throw new ArgumentNullException(nameof(property));

            object notifyPropObj = builder.Create(property.DeclaringType);

            if (!(notifyPropObj is INotifyPropertyChanged notifyProp))
                throw new ArgumentException($"The provided property must belong to a type implementing the '{typeof(INotifyPropertyChanged)}' interface");

            bool raised = false;

            try
            {
                notifyProp.PropertyChanged += OnPropertyChanged;

                object newPropValue = builder.Create(property);
                property.SetValue(notifyProp, newPropValue);

                if (!raised)
                {
                    string errorMsg = PropertyChangedDidNotRaise(property);
                    throw new PropertyChangedException(errorMsg);
                }
            }
            finally
            {
                notifyProp.PropertyChanged -= OnPropertyChanged;
            }

            void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (raised)
                {
                    string errorMsg = PropertyChangedRaisedMultipleEvents(property);
                    throw new PropertyChangedException(errorMsg);
                }

                if (e.PropertyName != property.Name)
                {
                    string errorMsg = PropertyChangedRaisedWithWrongName(property, e.PropertyName);
                    throw new PropertyChangedException(errorMsg);
                }

                raised = true;
            }
        }

        private static string PropertyChangedDidNotRaise(PropertyInfo property)
            => $"Modifiying the {property.Name} property does not raise the PropertyChanged event";

        private static string PropertyChangedRaisedMultipleEvents(PropertyInfo property)
            => $"Modifiying the {property.Name} property raises the PropertyChanged event several times";

        private static string PropertyChangedRaisedWithWrongName(PropertyInfo property, string name)
            => $"Modifiying the {property.Name} property raises the PropertyChanged event with a wrong name ({name})";
    }
}