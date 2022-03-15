using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using SimpleAspNetApiDemo.Controllers;
using SimpleAspNetApiDemo.DataAccess;
using System.Linq;

namespace SimpleAspNetApiDemo.Tests.ControllerTests
{
    [TestFixture]
    public class TeacherControllerTests
    {
        [Test]
        public void BlankTest()
        {
            using SchoolContext schoolContext = TestUtilities.GetBlankContext();
            ILogger<TeacherController> logger = Substitute.For<ILogger<TeacherController>>();
            TeacherController controller = new(logger, schoolContext);

            int actualCount = controller.Get().Count();

            Assert.That(actualCount, Is.EqualTo(0));
        }

        [Test]
        public void SampleTest()
        {
            using SchoolContext schoolContext = TestUtilities.GetSampleContext();
            ILogger<TeacherController> logger = Substitute.For<ILogger<TeacherController>>();
            TeacherController controller = new(logger, schoolContext);

            int actualCount = controller.Get().Count();

            Assert.That(actualCount, Is.EqualTo(2));
        }
    }
}
