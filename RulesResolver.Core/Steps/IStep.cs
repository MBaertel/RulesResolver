using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Steps
{
    public interface IStep
    {
        StepOutcome Execute(object? input);
    }

    public interface IStep<TIn,TOut> : IStep
    {
        StepOutcome<TOut> Execute(TIn input);
    }
}
