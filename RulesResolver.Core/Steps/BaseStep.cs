using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Steps
{
    public abstract class BaseStep<TIn,TOut> : IStep<TIn,TOut>
    {
        StepOutcome IStep.Execute(object? input)
        {
            if(input is TIn typedInput)
            {
                var result = ExecuteTyped((TIn?)input);
                return result;
            }
            throw new InvalidCastException($"input was of type {input?.GetType()}, expected {typeof(TIn)}");
        }

        StepOutcome<TOut> IStep<TIn, TOut>.Execute(TIn? input) =>
            ExecuteTyped(input);

        protected abstract StepOutcome<TOut> ExecuteTyped(TIn? input);
    }
}
