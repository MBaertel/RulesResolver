using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Steps
{
    public abstract class BaseStep<TIn,TOut> : IStep<TIn,TOut>
    {
        StepResult IStep.Execute(object input, out object output)
        {
            var result = ExecuteTyped((TIn)input, out var typedOutput);
            output = typedOutput!;
            return result;
        }

        StepResult IStep<TIn, TOut>.Execute(TIn input, out TOut output) =>
            ExecuteTyped((TIn)input, out output);

        protected abstract StepResult ExecuteTyped(TIn input, out TOut output);
    }
}
