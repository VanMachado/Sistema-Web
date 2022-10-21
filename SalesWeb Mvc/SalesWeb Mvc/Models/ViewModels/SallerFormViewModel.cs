namespace SalesWeb_Mvc.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; }
        public ICollection<Departament> Departments { get; set; } = new List<Departament>();
    }
}
