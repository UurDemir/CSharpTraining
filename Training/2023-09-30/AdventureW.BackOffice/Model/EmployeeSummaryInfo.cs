namespace AdventureW.BackOffice.Model
{
    public class EmployeeSummaryInfo
    {
        public int Id { get; set; }
        public string SuperVisor { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Photo { get; set; }
    }
}
