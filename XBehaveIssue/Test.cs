using System;
using Xbehave;
using Xunit;

namespace XBehaveIssue
{
    public class Test
    {
        public class Calculator
        {
            public int Add(int x, int y) => x + y;
        }

        [Scenario]
        public void Addition(int x, int y, Calculator calculator, int answer)
        {
            "Given the number 1"
                .x(() => x = 1);

            "And the number 2"
                .x(() =>
                {
                    y = 2;
                    throw new Exception();
                });

            "And a calculator"
                .x(() => calculator = new Calculator());

            "When I add the numbers together"
                .x(() => answer = calculator.Add(x, y));

            "Then the answer is 3"
                .x(() => Xunit.Assert.Equal(3, answer));
        }
    }
}
