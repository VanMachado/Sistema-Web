namespace SalesWeb_Mvc.Models.ViewModels
{
    public class SallerFormViewModel
    {
        public Seller Seller { get; set; }
        public ICollection<Departament> Departaments { get; set; } = new List<Departament>();
    }
}
