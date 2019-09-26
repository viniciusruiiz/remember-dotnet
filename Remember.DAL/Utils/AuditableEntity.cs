using NHibernate.Event;
using NHibernate.Persister.Entity;
using Remember.Domain.Entity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Remember.DAL.Utils
{
    public class AuditEventListener : IPreUpdateEventListener, IPreInsertEventListener
    {
        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            if (!(@event.Entity is ITimeStampable audit))
                return false;

            var time = DateTime.Now;

            Set(@event.Persister, @event.State, "UpdatedAt", time);

            audit.UpdatedAt = time;

            return false;
        }

        public bool OnPreInsert(PreInsertEvent @event)
        {
            if (!(@event.Entity is ITimeStampable audit))
                return false;

            var time = DateTime.Now;

            Set(@event.Persister, @event.State, "CreatedAt", time);
            Set(@event.Persister, @event.State, "UpdatedAt", time);

            audit.CreatedAt = time;
            audit.UpdatedAt = time;

            return false;
        }

        private void Set(IEntityPersister persister, object[] state, string propertyName, object value)
        {
            var index = Array.IndexOf(persister.PropertyNames, propertyName);
            if (index == -1)
                return;
            state[index] = value;
        }

        public Task<bool> OnPreInsertAsync(PreInsertEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> OnPreUpdateAsync(PreUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
