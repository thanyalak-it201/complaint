namespace Complaint.Models
{
    public class Employee
    {
        public virtual int Emp_Id { get; set; }
        public virtual string? Emp_name { get; set; }
        public virtual string? Emp_department { get; set; }
        public virtual string? Emp_section { get; set; }
        public virtual string? Emp_position { get; set; }
    }
}
