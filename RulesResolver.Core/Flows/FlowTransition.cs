using RulesResolver.Core.Context;
using RulesResolver.Metadata.Ids;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Flows
{
    public class FlowTransition
    {
        public StepNodeId Target { get; }
        public Func<FlowContext,object> Transform { get; }
        public Func<FlowContext, bool>? Condition { get; }

        public FlowTransition(
            StepNodeId target,
            Func<FlowContext, object> transform,
            Func<FlowContext, bool> condition)
        {
            Target = target;
            Transform = transform;
            Condition = condition;
        }
    }
}
