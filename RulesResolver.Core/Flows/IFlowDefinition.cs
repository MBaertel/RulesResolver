using RulesResolver.Core.Context;
using RulesResolver.Metadata.Ids;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Flows
{
    public interface IFlowDefinition
    {
        StepId EntryStep { get; }

        FlowContinuation? GetNextStep(
            StepId currentStep,
            object lastStepOutput,
            FlowContext context);

        bool Validate(out string error);
    }
}
