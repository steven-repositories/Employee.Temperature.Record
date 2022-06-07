using Employee.Temperature.Record.Api.Entities;
using Employee.Temperature.Record.Api.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Employee.Temperature.Record.Api.Services {
    internal abstract class RestBase {
        protected AppDbContext _dbContext;

        public RestBase(AppDbContext dbContext) {
            _dbContext = dbContext;
        }

        protected IQueryable<Laborer> GetQueryable() {
            return _dbContext
                .Set<Laborer>()
                .Include(p => p.Person)
                .Include(t => t.Temperature);
        }
    }
}
