using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestGen.APP;
using Xunit;

namespace UnitTextGen.Test
{
    public class CalculaterTest
    {
        public Calculater calculater { get; set; }
        public Mock<ICalculatorService> myMock { get; set; }

        public CalculaterTest()
        {
            myMock = new Mock<ICalculatorService>();
            this.calculater = new Calculater(myMock.Object);
        }

        [Theory]
        [InlineData(2, 5, 7)]
        public void AddTest2(int a, int b, int exceptedTotal)
        {
            myMock.Setup(x => x.Add(a, b)).Returns(exceptedTotal);

            var actualTotal = calculater.Add(a, b);

            Assert.Equal(exceptedTotal, actualTotal);
        }

        [Theory]
        [InlineData(3, 5, 15)]
        public void Multip_SimpleValues_ReturnsMultipValue(int a, int b ,int exceptedTotal)
        {
            //doğrulama işlemleri
            //myMock.Setup(x => x.Multip(a, b)).Returns(exceptedTotal);

            //Assert.Equal(15, calculater.Multip(a, b));
            //myMock.Verify(x => x.Multip(a, b), Times.Once);

            //hata işlemleri kontrol için
            //myMock.Setup(x => x.Multip(a, b)).Throws(new Exception("a=0 olamaz"));
            //var exception = Assert.Throws<Exception>(() => calculater.Multip(a, b));
            //Assert.Equal("a=0 olamaz", exception.Message);

            //parametreli gönderme CallBack kullanımı
            int actualMultip = 0;
            myMock.Setup(x => x.Multip(It.IsAny<int>(), It.IsAny<int>() )).Callback<int,int>((x,y)=> actualMultip= x*y).Returns(exceptedTotal);

            calculater.Multip(a, b);

            Assert.Equal(15, actualMultip);

            calculater.Multip(5, 20);
            Assert.Equal(100, actualMultip);

        }
    }
}
