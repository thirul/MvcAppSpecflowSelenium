using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MvcApplication1.AcceptanceTests.Features.Calculator
{
    [Binding]
    public class CalculatorSteps
    {
        Calculator _calculator = null;
        int _result = 0;

        [BeforeScenario]
        public void Setup()
        {
            _calculator = new Calculator();
        }


        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            //ScenarioContext.Current.Pending();
            _calculator.AddNumber(p0);
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            //ScenarioContext.Current.Pending();
            _result = _calculator.Add();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.AreEqual(p0, _result);
        }
    }

    public class Calculator
    {
        IList<int> _numbers = new List<int>();

        internal void AddNumber(int p0)
        {
            _numbers.Add(p0);
        }

        internal int Add()
        {
            return _numbers.Sum();
        }
    }
}
