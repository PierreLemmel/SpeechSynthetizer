using AutoFixture;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Troikatorz.Speech.Tests.Assertions;
using Xunit;

namespace Troikatorz.Speech.GUI.Tests
{
    public abstract class ViewModelFacts<TViewModel, TModel>
        where TViewModel : ViewModelBase<TModel>, new()
        where TModel : class, new()
    {
        private readonly IFixture fixture;
        private readonly PropertyChangedAssertion propAssertion;

        protected ViewModelFacts()
        {
            fixture = new Fixture();
            propAssertion = new PropertyChangedAssertion(fixture);
        }

        [Theory]
        [MemberData(nameof(ViewModelPropertiesSource))]
        public void Raise_PropertyChanged_With_Property_Name_When_A_Property_Has_Changed(PropertyInfo property)
        {
            propAssertion.Verify(property);
        }

        public static IEnumerable<object[]> ViewModelPropertiesSource
        {
            get
            {
                return typeof(TViewModel)
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(prop => prop.CanRead && prop.CanWrite)
                    .Select(prop => new object[] { prop });
            }
        }
    }
}
