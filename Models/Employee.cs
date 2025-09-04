namespace asp_member_prac.Models
{
    public class Employee
    {
        public string EmpId { get; set; } = null!;
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Mail { get; set; }
        public int? Salary { get; set; }
        public DateTime? EmploymentDate { get; set; }
    }
}