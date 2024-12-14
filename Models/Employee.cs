namespace edu.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public List<Language> KnownLanguages { get; set; } = new List<Language>();
    }

    public class Language
    {
        public required string LanguageName { get; set; }
        public int ScoreOutof100 { get; set; }
    }
}
