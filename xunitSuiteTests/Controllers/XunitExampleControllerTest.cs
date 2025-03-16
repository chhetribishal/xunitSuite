using Moq;
using System;
using System.Collections;
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

        [Theory] // If parameter is expected by method use Theory
        [InlineData(80, "Wrong! Try a bigger number.")]
        [InlineData(120, "Wrong! Try a smaller number.")]
        [InlineData(100, "You guessed correct number.")]

        public void XunitExampleController_Index_ValidNumber(int number, string expectedResult)
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
            XunitExampleController controller = new XunitExampleController(printerMockService.Object, emailMocKService.Object);
            int guessedNumber = number;
            //Act -

            string result = controller.Index(guessedNumber);
            //Assert -
            Assert.Equal(expectedResult, result);
            emailMocKService.Verify(x => x.SendEmail(), Times.Once);
        }

        [Theory]
        [ClassData(typeof(ValidNumberCollection))]
        public void XunitExampleController_Index_ValidNumberWithClassData(int number, string expectedResult)
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
            XunitExampleController controller = new XunitExampleController(printerMockService.Object, emailMocKService.Object);
            int guessedNumber = number;
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
            //Assert.Equal(expectedResult, result);
            Assert.Contains("Wrong", expectedResult);
            Assert.DoesNotContain("wrong", expectedResult);
            Assert.DoesNotMatch("\\d", expectedResult);
            Assert.Empty(new List<int>());
            Assert.False(false);
            Assert.IsType<string>(expectedResult);
            Assert.NotEmpty(new List<int> {1,2});
            Assert.NotNull("");
            Assert.NotSame(new object(), new object());
            Assert.Single(new List<int> { 4});
            Assert.StartsWith("Wrong", expectedResult);
            Assert.True(true);
            emailMocKService.Verify(x => x.SendEmail(),Times.Never);
            printerMockService.Verify(x => x.SendPrint("print this message"), Times.Once); //This will cause not to pass unit tes because content is different from what it shoudl be
        }

        [Fact]

        public void XunitExampleController_Index_ValidateNumberWithException()
        {
            Mock<IEmailService> emailMockService = new Mock<IEmailService>();
            emailMockService.Setup(x => x.IsEmailAvailable()).Throws(new ArgumentException());
            Mock<IPrinterService> printerMockService = new Mock<IPrinterService>();
            XunitExampleController controller = new XunitExampleController(printerMockService.Object, emailMockService.Object);

            //Act-

            //Assert -

            Assert.Throws<ArgumentNullException>(() =>
            {
                controller.Index(34);
            });
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

        class ValidNumberCollection : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { 80, "Wrong! Try a bigger number." };
                yield return new object[] { 120, "Wrong! Try a smaller number." };
                yield return new object[] { 100, "You guessed correct number." };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
