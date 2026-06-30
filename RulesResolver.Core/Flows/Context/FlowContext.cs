using RulesResolver.Core.Flows;
using RulesResolver.Core.Flows.Instances;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Core.Context
{
    public sealed class FlowContext
    {
        private readonly FlowInstance _instance;

        public object? Payload => _instance.Payload;
        
        public void SetVariable(string key,object? value) =>
            _instance.SetVariable(key,value);
        
        public bool TryGetVariable(string key, out object? value) =>
            _instance.TryGetVariable(key, out value);

        public FlowContext(FlowInstance instance)
        {
            _instance = instance;
        }
    }
}
