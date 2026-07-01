using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Steps
{
    public abstract class BaseAsyncStep<TIn, TOut> : IStep<TIn, TOut>
    {
        StepOutcome IStep.Execute(object? input)
            => ExecuteTyped((TIn?)input);

        StepOutcome<TOut> IStep<TIn, TOut>.Execute(TIn input)
            => ExecuteTyped(input);

        protected abstract Task<TOut> ExecuteAsync(TIn? input);

        protected virtual Guid StepId => GetType().GUID;

        private StepOutcome<TOut> ExecuteTyped(TIn? input)
        {
            var await = new StepAwait(StepId, input);

            await.AttachTask(async () =>
            {
                var result = await ExecuteAsync((TIn?)await.Input);
                return (object?)result;
            });

            return StepOutcome(await);
        }
    }
}
