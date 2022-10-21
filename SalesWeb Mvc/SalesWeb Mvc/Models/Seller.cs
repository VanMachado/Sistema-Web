using System.ComponentModel.DataAnnotations;

namespace SalesWeb_Mvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        
        [Display(Name = "Base salary")]
        [DisplayFormat(DataFormatString = "$ {0:F2}")]
        public double BaseSalary { get; set; }
        public Departament Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }
     
        public Seller(int id, string name, string email, DateTime birthDate, 
            double baseSalary, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = departament;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime init, DateTime final)
        {           
            return Sales.Where(sr => sr.Date > init && sr.Date <= final)
                .Sum(sr => sr.Amount);
        }     
    }
}
