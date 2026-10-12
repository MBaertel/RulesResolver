using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace RulesResolver.Core.Steps
{
    public class StepResult
    {
        public StepStatus Status { get; }

        protected StepResult(StepStatus status)
        {
            Status = status;
        }

        public static StepResult Continue(object? output) =>
            new(StepResult.Continue, output);

        public static StepResult Suspend(Await awaitable) =>
            new(StepResult.Suspend, null, awaitable);
    }

    public sealed class StepResult<T> : StepResult
    {
        public new T? Output { get; }

        private StepResult(StepResult status, T? output = default)
            : base(status)
        {
            Output = output;
        }

        public static StepResult<T> Continue(T output) =>
            new(StepResult.Continue, output);

        public static StepResult<T> Suspend() =>
            new(StepResult.Suspend, default);
    }
}
