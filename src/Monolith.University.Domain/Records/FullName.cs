namespace Monolith.University.Domain.Records
{
    public record FullName
    {
        public string? FirstName { get; private init; }
        public string? MiddleName { get; private init; }
        public string? LastName { get; private init; }

        // Empty constructor in this case is required by EF Core,
        // because has a complex type as a parameter in the default constructor.
        private FullName()
        {

        }

        public FullName(string? FirstName, string? MiddleName, string? LastName)
        {
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
        }
    }
}
