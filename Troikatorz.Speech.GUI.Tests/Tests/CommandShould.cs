using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Troikatorz.Speech.GUI.Tests
{
    public class CommandShould
    {
        [Fact]
        public void Command_Should_Fire_CanExecuteChanged_When_When_Predicate_Is_Matched()
        {
            

            Command command = new Command(null, object => true)
        }
    }
}
