namespace Monolith.University.Core.Contracts.Records
{
    public record FullNameRecord
    {
        public string? FirstName { get; private init; }
        public string? MiddleName { get; private init; }
        public string? LastName { get; private init; }

        // Empty constructor in this case is required by EF Core,
        // because has a complex type as a parameter in the default constructor.
        private FullNameRecord()
        {

        }

        public FullNameRecord(string? FirstName, string? MiddleName, string? LastName)
        {
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
        }
    }
}
