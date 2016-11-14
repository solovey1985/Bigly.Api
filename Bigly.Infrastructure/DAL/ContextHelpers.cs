using System.Data.Entity;

namespace Bigly.Infrastructure.DAL
{
    public static class ContextHelpers
    {
        public static void ApplyStateChanges(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<Entity>())
            {
                Entity entity = entry.Entity;
                entry.State = StateHelper.ConvertState(entity.State);
            }
        }
    }
}
