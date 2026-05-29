using RulesResolver.Core.Context;
using RulesResolver.Metadata.Ids;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Flows
{
    public class FlowTransition
    {
        public StepId Target { get; }
        public Func<FlowContext,object,object> Transform { get; }
        public Func<FlowContext,object , bool> Condition { get; }

        public FlowTransition(
            StepId target,
            Func<FlowContext, object, object> transform,
            Func<FlowContext, object, bool> condition)
        {
            Target = target;
            Transform = transform;
            Condition = condition;
        }
    }
}
