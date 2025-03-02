using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xunitSuite.Controllers;
using xunitSuite.Services;

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
            //IPrinterService _printerService = new PrinterService();
            //IEmailService _emailService = new EmailService();

            Mock<IEmailService> emailMocKService = new Mock<IEmailService>();
            emailMocKService.Setup(x => x.IsEmailAvailable()).Returns(true);
            emailMocKService.Setup(x => x.SendEmail()).Verifiable();
            Mock<IPrinterService> printerMockService = new Mock<IPrinterService>();
            printerMockService.Setup(x => x.IsPrinterAvailable()).Returns(true);
            XunitExampleController controller = new XunitExampleController(printerMockService.Object,emailMocKService.Object);
            int guessedNumber = 120;
            string expectedResult = "Wrong! Try a smaller number.";
            //Act -

            string result = controller.Index(guessedNumber);
            //Assert -
            Assert.Equal(expectedResult, result);
            emailMocKService.Verify(x => x.SendEmail(), Times.Once);
        }
        [Fact]
        public void XunitExampleController_Index_ValidLargeNumberWithoutEmailServiceResult()
        {
            ///AAA
            ///Arrange -
            //IPrinterService _printerService = new PrinterService();
            //IEmailService _emailService = new EmailService();

            Mock<IEmailService> emailMocKService = new Mock<IEmailService>();
            emailMocKService.Setup(x => x.IsEmailAvailable()).Returns(false);
            emailMocKService.Setup(x => x.SendEmail()).Verifiable();
            Mock<IPrinterService> printerMockService = new Mock<IPrinterService>();
            printerMockService.Setup(x => x.IsPrinterAvailable()).Returns(true);
            printerMockService.Setup(x => x.SendPrint(It.IsAny<string>())).Verifiable();
            XunitExampleController controller = new XunitExampleController(printerMockService.Object, emailMocKService.Object);
            int guessedNumber = 120;
            string expectedResult = "Wrong! Try a smaller number.";
            //Act -

            string result = controller.Index(guessedNumber);
            //Assert -
            Assert.Equal(expectedResult, result);
            emailMocKService.Verify(x => x.SendEmail(),Times.Never);
            printerMockService.Verify(x => x.SendPrint("print this messagebishal"), Times.Once); //This will cause not to pass unit tes because content is different from what it shoudl be
        }

        /*
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
        */
    }
}
