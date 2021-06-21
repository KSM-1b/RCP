using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using RCP.Controllers;

namespace RCP.Tests
{
    public class ReportActionsTests
    {
        [Test]
        public void Index_ReturnsNotNull()
        {
            //Arrange
            ReportController controller = new ReportController(null);
            
            //Action
            Task<IActionResult> result = controller.Index();
            
            //Assert
            Assert.IsNotNull(result);
        }
    }
}