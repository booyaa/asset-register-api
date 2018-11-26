using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomesEngland.Gateway.DataGenerator.Test
{
    [TestClass]
    public class InputSanitizerTests
    {
        private IInputSanitizer _classUnderTest;
        public InputSanitizerTests(IInputSanitizer inputSanitizer)
        {

        }

        [TestMethod]
        public async Task GivenValidInput_DataGenerator_PassesCorrectNumberOfRecord()
        {

        }
    }
}
