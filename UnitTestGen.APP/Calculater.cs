using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestGen.APP
{
    public class Calculater
    {
        private ICalculatorService _calculatorService { get; set; }
        public Calculater(ICalculatorService calculatorService)
        {
            this._calculatorService = calculatorService;
        }

        public int Add(int a,int b)
        {
            return _calculatorService.Add(a, b);
        }

        public int Multip(int a, int b)
        {
            return _calculatorService.Multip(a, b);
        }
    }
}
