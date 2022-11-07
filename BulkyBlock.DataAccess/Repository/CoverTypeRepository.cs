using BulkyBlock.DataAccess.Repository.IRepository;
using BulkyBlock.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBlock.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
           
        }
       

        public void Update(CoverType category)
        {
            _db.CoverTypes.Update(category);
        }
    }
}
