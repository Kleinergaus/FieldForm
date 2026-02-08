using FieldForm.API;
using FieldForm.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestFieldForm
{
    internal class TestSetMarginLeftTop
    {
        [Test]
        public void Test_ValidLeftAndTop_CoordinatesAreSet()
        {
            // Arrange
            IGridView? result = GridFactory.CreateGridView(10, 10);
            Assert.That(result, Is.Not.Null);

            // Act 
            result.SetMarginLeftTop(120, 100);


            // Assert
            Assert.That(result.MarginLeft, Is.EqualTo(120));
            Assert.That(result.MarginTop, Is.EqualTo(100));
        }

        [Test]
        public void Test_ValidLeftAndInvalidTop_CoordinatesAreNotSet()
        {
            // Arrange
            IGridView? result = GridFactory.CreateGridView(10, 10);
            Assert.That(result, Is.Not.Null);

            // Act 
            result.SetMarginLeftTop(120, -100);


            // Assert
            Assert.That(result.MarginLeft, Is.EqualTo(0));
            Assert.That(result.MarginTop, Is.EqualTo(0));
        }


        [Test]
        public void Test_InvalidLeftAndValidTop_CoordinatesAreNotSet()
        {
            // Arrange
            IGridView? result = GridFactory.CreateGridView(10, 10);
            Assert.That(result, Is.Not.Null);

            // Act 
            result.SetMarginLeftTop(-120, 100);


            // Assert
            Assert.That(result.MarginLeft, Is.EqualTo(0));
            Assert.That(result.MarginTop, Is.EqualTo(0));
        }
    }
}
