using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Steps
{
    public interface IStep
    {
        StepResult<object> Execute(object? input);
    }

    public interface IStep<TIn,TOut> : IStep
    {
        StepResult<TOut> Execute(TIn input);
    }
}
