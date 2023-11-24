using Lab3_PonomarevaFO;
using Moq;
using System.Data.SqlClient;
using System.Text;

namespace TestInt
{
    public class Tests
    {
        

        [Test]
        public void Testing_Send()
        {
            // Arrange
            var mockDataTransfer = new Mock<IDataTransfer>();
            var classAddiction = new ClassAddiction()
            {
                DataTransfer = mockDataTransfer.Object
            };

            var consoleOutput = new StringBuilder();
            Console.SetOut(new StringWriter(consoleOutput));

            // Act
            classAddiction.Send("Data");

            // Assert
            Assert.AreEqual("Отправка данных на email-сервер: Data\r\n", consoleOutput.ToString());
        }
        [Test]
        public void Testing_UserInterface()
        {
            // Arrange
            var consoleInput = new StringReader("1\n2\n3\n4\n5\n6\n7\n8\n9\n1\n2\n3\n");
            Console.SetIn(consoleInput);

            var userInterface = new ConsoleUserInterface();

            var consoleOutput = new StringBuilder();
            Console.SetOut(new StringWriter(consoleOutput));

            // Act
            userInterface.GetUserInput();

            // Assert
            Assert.That(consoleOutput.ToString(), Is.EqualTo("Введите стороны треугольника:\r\nВведите координаты вершин треугольника:\r\nВведите значения a, b, c:\r\nРазносторонний\r\n"));
        }

    }
}