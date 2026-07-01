using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace RulesResolver.Core.Steps
{
    public class StepOutcome
    {
        public StepResult Result { get; }
        public object? Output { get; }
        public Await? Await { get; }

        protected StepOutcome(StepResult state, object? output = null, Await? awaitable = null)
        {
            Result = state;
            Output = output;
            Await = awaitable;
        }

        public static StepOutcome Continue(object? output) =>
            new(StepResult.Continue, output);

        public static StepOutcome Suspend(Await awaitable) =>
            new(StepResult.Suspend, null, awaitable);
    }

    public sealed class StepOutcome<T> : StepOutcome
    {
        public new T? Output => (T?)base.Output;

        private StepOutcome(StepResult state, T? output = default, Await? awaitable = null)
            : base(state, output, awaitable)
        {
        }

        public static StepOutcome<T> Continue(T output) =>
            new(StepResult.Continue, output);

        public static StepOutcome<T> Suspend(Await awaitable) =>
            new(StepResult.Suspend, default, awaitable);
    }
}
