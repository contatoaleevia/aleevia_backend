using System.Transactions;

namespace CrossCutting.Databases;

public static class ApiTransactionScope
{
    public static TransactionScope RepeatableRead(bool async)
    {
        return new TransactionScope(TransactionScopeOption.Required,
            new TransactionOptions
                { IsolationLevel = IsolationLevel.RepeatableRead, Timeout = new TimeSpan(00, 10, 0) },
            async ? TransactionScopeAsyncFlowOption.Enabled : TransactionScopeAsyncFlowOption.Suppress);
    }
}