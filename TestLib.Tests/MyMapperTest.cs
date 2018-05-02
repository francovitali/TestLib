using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib.Dto;
using TestLib.Model;

namespace TestLib.Tests
{
    [TestClass]
    public class MyMapperTest
    {
        private MyMapper myMapper;

        [TestInitialize]
        public void Initialize()
        {
            myMapper = new MyMapper();
        }

        [TestMethod]
        public void MyMapperTest_WithOrder_ShouldMapIdAndDateFields()
        {
            // Arrange
            int orderId = 666;
            DateTime now = DateTime.Now;

            var order = new Order()
            {
                Id = orderId,
                Date = now
            };

            // Act
            OrderDto orderDto = myMapper.Map(order);

            // Assert
            Assert.AreEqual(orderId, orderDto.Id);
            Assert.AreEqual(now, orderDto.Date);
        }

        [TestMethod]
        public void MyMapperTest_WhenOrderHasDiscount_ShouldMapDiscountPrice()
        {
            // Arrange
            double originalPrice = 100;
            double discount = 10;
            double discountPrice = 90;

            var order = new Order()
            {
                OriginalPrice = originalPrice,
                Discount = discount
            };

            // Act
            OrderDto orderDto = myMapper.Map(order);

            // Assert
            Assert.AreEqual(discountPrice, orderDto.Price);
        }
    }
}
