using RulesResolver.Core.Context;
using RulesResolver.Core.Flows.Nodes;
using RulesResolver.Metadata.Ids;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Flows.Definitions
{
    /// <summary>
    /// The Flow Definition contains a blueprint for a flow
    /// </summary>
    public class FlowDefinition
    {
        public FlowId Id { get; }
        public Guid EntryStepId { get; }
        public IReadOnlyDictionary<Guid,FlowNode> Steps { get; }

        public FlowDefinition(
            FlowId id,
			Guid entryStepId,
            IReadOnlyDictionary<Guid, FlowNode> steps)
        {
            Id = id;
            EntryStepId = entryStepId;
            Steps = steps;
        }
    }
}
