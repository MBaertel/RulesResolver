using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Steps
{
    public abstract record StepOutcome
    {
        public abstract StepResult Result { get; }
    }

    public sealed record StepOutcome<T>(T Output) : StepOutcome
    {
        public override StepResult Result => StepResult.Continue;
    }

    public sealed record Continue(object? Output) : StepOutcome
    {
        public override StepResult Result => StepResult.Continue;
    }
    public sealed record Suspend(Await Await) : StepOutcome
    {
        public override StepResult Result => StepResult.Suspend;
    }
    public sealed record Cancel : StepOutcome
    {
        public override StepResult Result => StepResult.Cancel;
    }
}
