using RulesResolver.Core.Flows.Instances;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Flows.Frames
{
    /// <summary>
    /// A Frame for flows, Effectively a container with its own Action Stack. Also holds necessary runtime data. Important for concurrent flows.
    /// </summary>
    public class FlowFrame
    {
        public FlowInstance FlowInstance { get; set; }
    }
}
