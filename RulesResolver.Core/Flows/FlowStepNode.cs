using RulesResolver.Metadata.Ids;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Flows
{
    public class FlowStepNode
    {
        public StepId Step { get; }
        public IReadOnlyList<FlowTransition> Transitions { get; }

        public FlowStepNode(
            StepId step,
            IReadOnlyList<FlowTransition> transitions)
        {
            Step = step;
            Transitions = transitions;
        }
    }
}
