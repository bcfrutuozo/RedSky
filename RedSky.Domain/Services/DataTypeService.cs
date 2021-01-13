using System.Linq;
using RedSky.Domain.Entities;
using RedSky.Domain.Interfaces.DbContextScope;
using RedSky.Domain.Interfaces.Repositories;
using RedSky.Domain.Interfaces.Services;

namespace RedSky.Domain.Services
{
    public class DataTypeService : ServiceBase<DataType>, IDataTypeService
    {
        private readonly IDbContextScopeFactory ContextScopeFactory;
        private readonly IRepositoryBase<DataType> Repository;

        public DataTypeService(IDbContextScopeFactory contextScopeFactory, IRepositoryBase<DataType> repository) : base(
            contextScopeFactory, repository)
        {
            this.ContextScopeFactory = contextScopeFactory;
            this.Repository = repository;
        }
    }
}
