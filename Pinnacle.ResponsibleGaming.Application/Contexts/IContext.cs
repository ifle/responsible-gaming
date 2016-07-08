using System.Data;


namespace Pinnacle.ResponsibleGaming.Application.Contexts
{
    public interface IContext
    {
        void BeginTransaction();
        void BeginTransaction(IsolationLevel isolationLevel);
        void Commit();
    }
}