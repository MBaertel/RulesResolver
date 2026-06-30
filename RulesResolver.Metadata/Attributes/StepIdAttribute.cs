namespace RulesResolver.Metadata.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false,Inherited = false)]
    public sealed class StepIdAttribute : Attribute
    {
        public string LocalIdString { get; }

        public StepIdAttribute(string localIdString)
        {
            if (string.IsNullOrWhiteSpace(localIdString))
                throw new ArgumentException("idString cannot be null or empty.", nameof(localIdString));

            LocalIdString = localIdString;
        }
    }
}
