namespace EmployeeManagement.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public string EmployeeNum { get; set; }

        public DateTime EmployedDate { get; set; }

        public DateTime? TerminatedDate { get; set; }

        public Person Person { get; set; }
    }
}