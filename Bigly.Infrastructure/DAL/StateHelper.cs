using System.Data.Entity;

namespace Bigly.Infrastructure.DAL
{
    public class StateHelper
    {
        public static EntityState ConvertState(State state)
        {
            switch (state)
            {
                    case State.Added:       return EntityState.Added;
                    case State.Modified:    return EntityState.Modified;
                    case State.Deleted:     return EntityState.Deleted;
                    case State.Unchanged:   return EntityState.Unchanged;
                    default:                return EntityState.Unchanged;
            }
        }
    }
}
