using RulesResolver.Core.Flows;
using RulesResolver.Core.Flows.Instances;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Context
{
    /// <summary>
    /// The Flow Context holds all runtime Data of the flow.
    /// </summary>
    public sealed class FlowContext
    {
        private object? _payload = null;

        private Dictionary<string, object?> _variables = 
            new Dictionary<string, object?>();

		public object? Payload
        {
            get => _payload;
            set => _payload = value;
        }

		public void SetVariable(string key, object? value) =>
            _variables[key] = value;
        
        public bool TryGetVariable(string key, out object? value) =>
            _variables.TryGetValue(key, out value);

        public FlowContext(object payload)
        {
            _payload = payload;
        }
    }
}
