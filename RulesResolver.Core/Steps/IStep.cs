using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Steps
{
    public interface IStep
    {
        StepResult Execute(object input, out object output);
    }

    public interface IStep<TIn,TOut> : IStep
    {
        StepResult Execute(TIn input, out TOut output);
    }
}
