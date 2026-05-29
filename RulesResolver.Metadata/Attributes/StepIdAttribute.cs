namespace RulesResolver.Metadata.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false,Inherited = false)]
    public sealed class StepIdAttribute : Attribute
    {
        public string IdString { get; }

        public StepIdAttribute(string idString)
        {
            if (string.IsNullOrWhiteSpace(idString))
                throw new ArgumentException("idString cannot be null or empty.", nameof(idString));

            IdString = idString;
        }
    }
}
