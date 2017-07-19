# XBehave Issue

Given the folling packages

```
<PackageReference Include="Microsoft.NET.Test.Sdk" Version="15.0.0" />
<PackageReference Include="Xbehave" Version="2.2.0-beta0003-build685" />
<PackageReference Include="xunit" Version="2.3.0-beta3-build3705" />
<PackageReference Include="xunit.runner.visualstudio" Version="2.3.0-beta3-build3705" />
```

and resharper

```
JetBrains ReSharper Ultimate 2017.1.2  Build 108.0.20170428.75743
```

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
