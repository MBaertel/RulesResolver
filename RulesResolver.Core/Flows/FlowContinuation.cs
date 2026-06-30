using RulesResolver.Metadata.Ids;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Flows
{
    public readonly struct FlowContinuation
    {
        public StepNodeId? NextStep { get; }
        public object? Input { get; }

        public FlowContinuation(StepNodeId? nextStep, object? input)
        {
            NextStep = nextStep;
            Input = input;
        }

        public static FlowContinuation End => new(null,null);
    }
}
