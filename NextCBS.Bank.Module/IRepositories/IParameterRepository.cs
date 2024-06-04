using NextCBS.Bank.Abstractions.Models;

namespace NextCBS.Bank.Module.IRepositories
{
    public interface IParameterRepository
    {

        Task<ParameterModel> UpsertParameter(ParameterModel parameterModel);
        Task<ParameterModel> GetParameter(int id);
        Task<IEnumerable<ParameterModel>> GetAllParameters();
     
    }
}
