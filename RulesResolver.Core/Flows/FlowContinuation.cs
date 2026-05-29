using RulesResolver.Metadata.Ids;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Flows
{
    public readonly struct FlowContinuation
    {
        public StepId? NextStep { get; }
        public object? Input { get; }

        public FlowContinuation(StepId? nextStep, object? input)
        {
            NextStep = nextStep;
            Input = input;
        }

        public static FlowContinuation End => new(null,null);
    }
}
