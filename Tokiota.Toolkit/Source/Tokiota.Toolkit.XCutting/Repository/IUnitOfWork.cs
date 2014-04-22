using System.Threading.Tasks;

namespace Tokiota.Toolkit.XCutting.Repository
{
    public interface IUnitOfWork
    {
        #region Public Methods and Operators

        int Commit();

        Task<int> CommitAsync();

        #endregion
    }
}