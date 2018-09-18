using BAL.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IUnitOfWork
    {
        IAuthenticateRepository AuthenticateRepo { get; }
        ICategoryRepository CategoryRepo { get; }
        IProductRepository ProductRepo { get; }
        IOrderRepository OrderRepo { get; }

        int SaveChanges();
    }
}
