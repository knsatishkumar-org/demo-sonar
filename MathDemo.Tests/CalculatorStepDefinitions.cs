using System;
using TechTalk.SpecFlow;

namespace MathDemo.Tests
{
    [Binding]
    public class CalculatorStepDefinitions
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int p0)
        {
            throw new PendingStepException();
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            throw new PendingStepException();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            throw new PendingStepException();
        }
    }
}
