using RulesResolver.Core.Context;
using RulesResolver.Metadata.Ids;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Flows.Definitions
{
    public class FlowDefinition
    {
        public FlowId Id { get; }
        public StepNodeId EntryStep { get; }
        public IReadOnlyDictionary<StepNodeId,FlowStepNode> Steps { get; }

        public FlowDefinition(
            FlowId id,
            StepNodeId entry,
            IReadOnlyDictionary<StepNodeId, FlowStepNode> steps)
        {
            Id = id;
            EntryStep = entry;
            Steps = steps;
        }

        public bool Validate(out string? error)
        {
            error = null;
            return true;
        }
    }
}
