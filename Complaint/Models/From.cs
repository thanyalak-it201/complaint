namespace Complaint.Models
{
    public class From
    {
        public virtual int From_Id { get; set; }
        public virtual string? From_data { get; set; }
        public virtual int To_Id { get; set; }
        public virtual int CC_Id { get; set; }
        public virtual string? From_name { get; set; }
        public virtual int Costomer_Id { get; set; }
        public virtual string? Product_Id { get; set; }
        public virtual string? lot { get; set; }
        public virtual int Problem_Id { get; set; }
        public virtual int number { get; set; }
        public virtual int Price { get; set; }
        public virtual string? Co { get; set; }
        public virtual int Type_Id { get; set; }
        public virtual string? Image { get;}
        public virtual string? Note { get;}
        public virtual int Operator_Id { get; set; }
        public virtual int Mg_Id { get; set; }
    }
}
