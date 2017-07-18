# XBehave Issue

When running the follow test via resharper

```csharp
[Scenario]
    public void Addition(int x, int y, Calculator calculator, int answer)
    {
        "Given the number 1"
            .x(() => x = 1);

        "And the number 2"
            .x(() =>
            {
                y = 2;

                //NOTE: An exception is throw during one of the steps
                throw new Exception();
            });

        "And a calculator"
            .x(() => calculator = new Calculator());

        "When I add the numbers together"
            .x(() => answer = calculator.Add(x, y));

        "Then the answer is 3"
            .x(() => Xunit.Assert.Equal(3, answer));
    }
```

Resharper's test runner is marking the test as inconclusive (not failed)

![Resharper output](https://i.imgur.com/FLGhOfX.png)
