using System.Collections.Generic;

namespace Core.Interface
{
    public interface ISqlRepository
    {
        List<List<object>> CallStoredProcedure(string StoredProcedureQueryString);
    }
}
