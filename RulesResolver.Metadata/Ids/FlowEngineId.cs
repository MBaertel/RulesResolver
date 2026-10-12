using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Text;

namespace RulesResolver.Metadata.Ids
{
    public readonly record struct FlowEngineId
    {
        public string Value { get; }

        public FlowEngineId(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("value cannot be empty", nameof(value));
            Value = value;
        }

        public static FlowEngineId Of(string value) => new(value);
    }

    public readonly record struct StepId
    {
        private const string prefix = "step";
        public string Value { get; }

        public StepId(string value)
        {
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentException("value cannot be empty", nameof(value));
			Value = value;
		}

        public override string ToString() =>
            prefix + "." + Value;
    }

    public readonly record struct FlowId
    {
		private const string prefix = "flow";
		public string Value { get; }

		public FlowId(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentException("value cannot be empty", nameof(value));
			Value = value;
		}

		public override string ToString() =>
			prefix + "." + Value;
	}
}
