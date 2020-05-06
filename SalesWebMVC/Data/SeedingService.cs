using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        { 
            if(_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; 
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3= new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Abercyldo", "abercyldo@gmail.com", new DateTime(1998, 4, 21), 1000, d1);
            Seller s2 = new Seller(2, "Weskleysson", "weskleysson@gmail.com", new DateTime(1995, 7, 8), 4000, d2);
            Seller s3 = new Seller(3, "Arnaldo", "arnaldo@gmail.com", new DateTime(1974, 2, 21), 2000, d3);
            Seller s4 = new Seller(4, "José Carlos", "josecarlos@gmail.com", new DateTime(1988, 4, 6), 9000, d4);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2020, 01, 18), 4000, SaleStatus.Billed, s4);

            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3, s4);

            _context.SalesRecord.Add(sr1);

            _context.SaveChanges();

        }
    }
}
