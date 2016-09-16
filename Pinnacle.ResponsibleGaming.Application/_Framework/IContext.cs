using System.Data;


namespace Pinnacle.ResponsibleGaming.Application.Framework
{
    public interface IContext
    {
        void BeginTransaction();
        void BeginTransaction(IsolationLevel isolationLevel);
        void Commit();
    }
}