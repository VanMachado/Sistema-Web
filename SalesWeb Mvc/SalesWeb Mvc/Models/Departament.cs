﻿namespace SalesWeb_Mvc.Models
{
    public class Departament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Departament()
        {
        }

        public Departament(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime init, DateTime final)
        {
            //double totalSales = 0;

            //foreach (Seller seller in Sellers)
            //{
            //    totalSales = seller.TotalSales(init, final);
            //}

            return Sellers.Sum(seller => seller.TotalSales(init, final));
        }
    }
}
