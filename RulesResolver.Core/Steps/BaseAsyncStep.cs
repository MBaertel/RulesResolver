using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Steps
{
    public abstract class BaseAsyncStep<TIn, TOut> : IStep<TIn, TOut>
    {
        StepResult<object> IStep.Execute(object? input)
            => ExecuteTyped((TIn?)input);

        StepResult<TOut> IStep<TIn, TOut>.Execute(TIn input)
            => ExecuteTyped(input);

        protected abstract Task<TOut> ExecuteAsync(TIn? input);

        protected virtual Guid StepId => GetType().GUID;

        private StepResult<TOut> ExecuteTyped(TIn? input)
        {
            var awaitable = new StepAwait(StepId, input);

            awaitable.AttachTask(async () =>
            {
                var result = await ExecuteAsync((TIn?)input);
                return (object?)result;
            });

            return StepResult<TOut>.Suspend(awaitable);
        }
    }
}
