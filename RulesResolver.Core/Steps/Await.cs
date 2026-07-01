using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Steps
{
    public abstract class Await
    {
        public Guid Id { get; }
        public bool Completed { get; protected set; }
        public object? Result { get; private set; }


        protected Task<object?>? Task;

        public Await(Guid? id = null)
        {
            this.Id = id ?? Guid.NewGuid();
        }

        internal void AttachTask(Task<object?> task)
        {
            if (Completed || Task != null)
                return;

            Task = task;
            task.ContinueWith(t =>
            {
                if (t.Status == TaskStatus.RanToCompletion)
                    Complete(t.Result);
                else if (t.IsFaulted)
                    throw t.Exception!;
            }, TaskContinuationOptions.ExecuteSynchronously);
        }

        internal void Complete(object? result)
        {
            Result = result;
            Completed = true;
        }
    }

    public sealed class StepAwait : Await
    {
        public Guid StepId { get; }
        public object? Input { get; }

        public StepAwait(Guid stepId, object? input = null,Guid? id = null)
            : base(id)
        {
            StepId = stepId;
            Input = input;
        }
    }

    public sealed class FlowAwait : Await
    {
        public Guid FlowId { get; }

        public FlowAwait(Guid flowId,Guid? id = null)
            : base(id)
        {
            FlowId = flowId;
        }
    }
}
