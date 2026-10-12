using RulesResolver.Core.Context;
using RulesResolver.Core.Flows.Instances;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Execution
{
	/// <summary>
	/// The Flow runner is responsible for actually executing the Flow.
	/// </summary>
	internal class FlowRunner
	{
		public FlowInstance FlowInstance { get; }
		public FlowContext Context { get; }
		public ExecutionStatus Status { get; private set; }

		private Guid currentStepId;

		public FlowRunner(FlowInstance flowInstance, FlowContext context)
		{
			FlowInstance = flowInstance;
			Context = context;
			Status = ExecutionStatus.Pending;
		}

		private void Step()
		{
			
		}

		private void Notify()
		{

		}

	}
}
