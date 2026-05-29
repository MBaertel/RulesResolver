using System;
using System.Collections.Generic;
using System.Text;

namespace RulesResolver.Metadata.Ids
{
    public readonly record struct FlowId
    {
        public string Value { get; }

        public FlowId(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("value cannot be empty", nameof(value));
            Value = value;
        }

        public static FlowId Of(string value) => new(value);
    }
}
