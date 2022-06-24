using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace MathDemo.Tests
{
    [Binding]
    public class CalculatorStepDefinitions
    {
        Calculator calc = new Calculator();
        
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            calc.Operand1 = p0;
        }

        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int p0)
        {
            calc.Operand2 = p0;
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            calc.Result = calc.Add();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.AreEqual(p0, calc.Result);
        }
    }
}
