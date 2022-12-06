using EcommerceApp.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private MainDbContext _db;

        public UnitOfWork(MainDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
