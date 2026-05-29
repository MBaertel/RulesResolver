using RulesResolver.Core.Context;
using RulesResolver.Metadata.Ids;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Flows
{
    public class FlowDefinition : IFlowDefinition
    {
        public FlowId Id { get; }

        public StepId EntryStep { get; }

        public IReadOnlyDictionary<StepId,FlowStepNode> Steps { get; }

        public FlowDefinition(
            FlowId id,
            StepId entry,
            IReadOnlyDictionary<StepId, FlowStepNode> steps)
        {
            Id = id;
            EntryStep = entry;
            Steps = steps;
        }

        public FlowContinuation? GetNextStep(StepId currentStep, object lastStepOutput, FlowContext context)
        {
            var node = Steps[currentStep];
            var transition = node.Transitions.FirstOrDefault(x => x.Condition(context, lastStepOutput));
            
            if (transition == null) 
                return FlowContinuation.End;
            
            return new FlowContinuation(transition.Target,transition.Transform(context,lastStepOutput));
        }

        public bool Validate(out string error)
        {
            throw new NotImplementedException();
        }
    }
}
