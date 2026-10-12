using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Steps
{
    public abstract class BaseStep<TIn,TOut> : IStep<TIn,TOut>
    {
        StepResult<object> IStep.Execute(object? input)
        {
            if(input is TIn typedInput)
            {
                var result = ExecuteTyped((TIn?)input);
                return result;
            }
            throw new InvalidCastException($"input was of type {input?.GetType()}, expected {typeof(TIn)}");
        }

        StepResult<TOut> IStep<TIn, TOut>.Execute(TIn? input) =>
            ExecuteTyped(input);

        protected abstract StepResult<TOut> ExecuteTyped(TIn? input);
    }
}
