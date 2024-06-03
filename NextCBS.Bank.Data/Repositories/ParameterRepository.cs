using NextCBS.Bank.Contracts;
using NextCBS.Bank.Module.Entities;
using NextCBS.Bank.Module.Exceptions;
using NextCBS.Bank.Module.IRepositories;
using NextCBS.Bank.Module.Models;

namespace NextCBS.Bank.Data.Repositories
{
    public class ParameterRepository : BaseRepository<Parameter>, IParameterRepository
    {
        private readonly AppDbContext _context;
        private readonly IUserMeta _meta;

        public ParameterRepository(AppDbContext context, IUserMeta meta) : base(context)
        {
            _context = context;
            _meta = meta;
        }

        public async Task<ParameterModel> GetParameter(int id)
        {
            var entity = await GetFirstByConditionAsync(p=>p.Id == id && p.TenantId==_meta.ClientId);
            if (entity == null)
            {
                throw new ParameterNotFoundException();
            }
            return ToModel(entity);
        }
        public async Task<IEnumerable<ParameterModel>> GetAllParameters()
        {
            var entities = await GetByConditionAsync(p=>p.TenantId == _meta.ClientId);
            if (entities==null)
            {
                return Enumerable.Empty<ParameterModel>();
            }
            return entities.Select(ToModel).ToList();

        }

       

        public async Task<ParameterModel> UpsertParameter(ParameterModel parameterModel)
        {
            if (parameterModel == null)
            {
                throw new ArgumentNullException(nameof(parameterModel));
            }

            Parameter entity = await GetByIdAsync(parameterModel.Id) ?? ToEntity(parameterModel);

            entity.AccountType = parameterModel.AccountType;
            entity.ParameterName = parameterModel.ParameterName;
            entity.ParameterValue = parameterModel.ParameterValue;

            if (parameterModel.Id == 0)
            {
                await InsertAsync(entity);
            }
            else
            {
                await UpdateAsync(entity);
            }

            parameterModel.Id = entity.Id;
            return ToModel(entity);
        }

        private Parameter ToEntity(ParameterModel model)
        {
            return new Parameter
            {
                Id = model.Id,
                TenantId = _meta.ClientId,
                AccountType = model.AccountType,
                ParameterName = model.ParameterName,
                ParameterValue = model.ParameterValue,
                CreatedBy = _meta.UserId,
            };
        }

        private ParameterModel ToModel(Parameter parameter)
        {
            return new ParameterModel
            {
                Id = parameter.Id,
                AccountType = parameter.AccountType,
                ParameterName = parameter.ParameterName,
                ParameterValue = parameter.ParameterValue,
            };
        }
    }
}
