using System;
using NUnit.Framework;
using RCP.Helpers;

namespace RCP.Tests
{
    public class ManHoursTests
    {
        [Test]
        public void GetManHours_ReturnsProperValue()
        {
            //Arrange
            ManHours manHours = new ManHours();
            DateTime startTask = new DateTime(2021, 2, 12, 10, 15, 0);
            DateTime endTask = new DateTime(2021, 2, 12, 10, 45, 0);
            
            //Act
            double result = manHours.GetManHours(startTask, endTask);
            
            Assert.AreEqual(30,result);
        }
    }
}