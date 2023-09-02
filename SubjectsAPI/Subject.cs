namespace SubjectsAPI
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public string SubjectType { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
        public string ProfessorName { get; set; } = string.Empty;
    }
}
