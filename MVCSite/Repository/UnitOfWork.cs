using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Abstraction;
using System.Data.Entity;
using ApplicationCore;
using BAL.Implementation;

namespace BAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext db;
        public UnitOfWork()
        {
            db = new DatabaseContext();
        }
        private IAuthenticateRepository _AuthenticateRepo;
        public IAuthenticateRepository AuthenticateRepo
        {
            get
            {
                if (_AuthenticateRepo == null)
                    _AuthenticateRepo = new AuthenticateRepository(db);

                return _AuthenticateRepo;
            }
        }

        private ICategoryRepository _CategoryRepo;
        public ICategoryRepository CategoryRepo
        {
            get
            {
                if (_CategoryRepo == null)
                    _CategoryRepo = new CategoryRepository(db);

                return _CategoryRepo;
            }
        }
        private IProductRepository _ProductRepo;
        public IProductRepository ProductRepo
        {
            get
            {
                if (_ProductRepo == null)
                    _ProductRepo = new ProductRepository(db);

                return _ProductRepo;
            }
        }
        private IOrderRepository _OrderRepo;
        public IOrderRepository OrderRepo
        {
            get
            {
                if (_OrderRepo == null)
                    _OrderRepo = new OrderRepository(db);

                return _OrderRepo;
            }
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
