using ETicket.Data.Base;
using ETicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Data.Services
{
    public class ProducterService : EntityBaseRepository<Producter>, IProdcuterService
    {
        public ProducterService(ApplicationDbContext options) : base(options)
        {

        }
    }
}
