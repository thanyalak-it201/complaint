namespace Complaint.Models
{
    public class Costomer
    {
        public virtual int Costomer_Id { get; set; }
        public virtual string? Costomer_name { get; set; }
        public virtual string? Telephone { get; set; }
        public virtual string? Address { get; set; }
        public virtual string? Product_Id { get; set;}
    }
}
