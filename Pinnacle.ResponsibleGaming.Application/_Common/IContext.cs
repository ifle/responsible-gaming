using System.Data;


namespace Pinnacle.ResponsibleGaming.Application._Common
{
    public interface IContext
    {
        void BeginTransaction();
        void BeginTransaction(IsolationLevel isolationLevel);
        void Commit();
    }
}