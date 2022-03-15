using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using SimpleAspNetApiDemo.Controllers;
using System.Linq;

namespace SimpleAspNetApiDemo.Tests.ControllerTests
{
    [TestFixture]
    public class TeacherControllerTests
    {
        [Test]
        public void BlankTest()
        {
            using TestDatabase database = TestDatabase.NewEmptyDatabase();
            ILogger<TeacherController> logger = Substitute.For<ILogger<TeacherController>>();
            TeacherController controller = new(logger, database.Context);

            int actualCount = controller.Get().Count();

            Assert.That(actualCount, Is.EqualTo(0));
        }

        [Test]
        public void SampleTest()
        {
            using TestDatabase database = TestDatabase.NewSampleDatabase();
            ILogger<TeacherController> logger = Substitute.For<ILogger<TeacherController>>();
            TeacherController controller = new(logger, database.Context);

            int actualCount = controller.Get().Count();

            Assert.That(actualCount, Is.EqualTo(2));
        }
    }
}
