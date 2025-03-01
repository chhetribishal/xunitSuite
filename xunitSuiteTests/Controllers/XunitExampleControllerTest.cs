using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xunitSuite.Controllers;

namespace xunitSuiteTests.Controllers
{
    public class XunitExampleControllerTest
    {

        [Fact] // If there are no parameter to send while testing

        //controllername_controllermethodname_Testingfunctionality
        public void XunitExampleController_Index_ValidLargeNumberResult()
        {
            ///AAA
            ///Arrange -

            XunitExampleController controller = new XunitExampleController();
            int guessedNumber = 120;
            string expectedResult = "Wrong! Try a smaller number.";
            //Act -

            string result = controller.Index(guessedNumber);
            //Assert -
            Assert.Equal(expectedResult, result);
        }

        [Fact] // If there are no parameter to send while testing

        //controllername_controllermethodname_Testingfunctionality
        public void XunitExampleController_Index_ValidSmallerNumberResult()
        {
            ///AAA
            ///Arrange -

            XunitExampleController controller = new XunitExampleController();
            int guessedNumber = 80;
            string expectedResult = "Wrong! Try a bigger number.";
            //Act -

            string result = controller.Index(guessedNumber);
            //Assert -
            Assert.Equal(expectedResult, result);
        }

        [Fact] // If there are no parameter to send while testing

        //controllername_controllermethodname_Testingfunctionality
        public void XunitExampleController_Index_ValidCorrectNumberResult()
        {
            ///AAA
            ///Arrange -

            XunitExampleController controller = new XunitExampleController();
            int guessedNumber = 100;
            string expectedResult = "You guessed correct number";
            //Act -

            string result = controller.Index(guessedNumber);
            //Assert -
            Assert.Equal(expectedResult, result);
        }
    }
}
