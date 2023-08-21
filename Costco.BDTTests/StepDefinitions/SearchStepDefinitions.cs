using System;
using TechTalk.SpecFlow;

namespace Costco.BDTTests.StepDefinitions
{
    [Binding]
    public class SearchStepDefinitions
    {
        [When(@"I input name of existing item to the search field")]
        public void WhenIInputNameOfExistingItemToTheSearchField()
        {
            throw new PendingStepException();
        }

        [Then(@"I should see header containing name of existing item which was inputted on the previous step")]
        public void ThenIShouldSeeHeaderContainingNameOfExistingItemWhichWasInputtedOnThePreviousStep()
        {
            throw new PendingStepException();
        }

        [When(@"I get total quantity of found goods")]
        public void WhenIGetTotalQuantityOfFoundGoods()
        {
            throw new PendingStepException();
        }

        [When(@"I filter search results by price")]
        public void WhenIFilterSearchResultsByPrice()
        {
            throw new PendingStepException();
        }

        [When(@"I get total quantity of filtered goods")]
        public void WhenIGetTotalQuantityOfFilteredGoods()
        {
            throw new PendingStepException();
        }

        [Then(@"Total quantity of found goods sould be greater then total quantity of filtered goods")]
        public void ThenTotalQuantityOfFoundGoodsSouldBeGreaterThenTotalQuantityOfFilteredGoods()
        {
            throw new PendingStepException();
        }

        [When(@"I input senseless line to the search field")]
        public void WhenIInputSenselessLineToTheSearchField()
        {
            throw new PendingStepException();
        }

        [Then(@"I should see header containing ""([^""]*)""")]
        public void ThenIShouldSeeHeaderContaining(string p0)
        {
            throw new PendingStepException();
        }
    }
}
