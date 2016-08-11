using System;

namespace FrontDesk.SharedKernel
{
    public abstract class Entity<T> : IEquatable<Entity<T>>
    {
        public T Id { get; protected set; }

        protected Entity(T id)
        {
            if (object.Equals(id, default(T)))
            {
                throw new ArgumentException("The ID cannot be the type's default value.", "id");
            }

            this.Id = id;
        }

        // EF requires an empty constructor
        protected Entity()
        {
        }

        // For simple entities, this may suffice
        // As Evans notes earlier in the course, equality of Entities is frequently not a simple operation
        public override bool Equals(object otherObject)
        {
            var entity = otherObject as Entity<T>;
            if (entity != null)
            {
                return this.Equals(entity);
            }
            return base.Equals(otherObject);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public bool Equals(Entity<T> other)
        {
            if (other == null)
            {
                return false;
            }
            return this.Id.Equals(other.Id);
        }
    }
}
