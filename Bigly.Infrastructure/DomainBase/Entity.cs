using System;

namespace Bigly.Infrastructure
{
    public interface IEntity
    {
        int Id { get; set; }
    }
    public abstract class Entity:IEntity
    {
        private int id;
        public State State { get; set; }
        /// < summary>
        ///     Default Constructor.
        /// </summary>
        protected Entity()
        {}

        /// < summary>
        ///     Overloaded constructor.
        /// </summary>
        /// < param name="key">
        ///     An < see cref="System.Object" /> that
        ///     represents the primary identifier value for the
        ///     class.
        /// </param>
        protected Entity(int id)
        {
            this.id = id;
        }

        /// < summary>
        ///     An < see cref="System.Object" /> that represents the
        ///     primary identifier value for the class.
        /// </summary>
        public int Id { get { return id; } set { id = value; } }

        #region Equality Tests

        /// < summary >
        /// Determines whether the specified entity is equal to the
        /// current instance.
        /// </summary >
        /// < param name="entity" > An < see cref="System.Object"/> that
        /// will be compared to the current instance. </param >
        /// < returns > True if the passed in entity is equal to the
        /// current instance. </returns >
        public override bool Equals(object entity)
        {
            if (entity == null || !(entity is Entity))
            {
                return false;
            }
            return (this == (Entity) entity);
        }

        /// < summary >
        /// Operator overload for determining equality.
        /// </summary >
        /// < param name="base1" > The first instance of an
        /// < see cref="Entity"/> . </param >
        /// < param name="base2" > The second instance of an
        /// < see cref="Entity"/> . </param >
        /// < returns > True if equal. </returns >
        public static bool operator ==(Entity base1,
            Entity base2)
        {
            // check for both null (cast to object or recursive loop)
            if ((object) base1 == null && (object) base2 == null)
            {
                return true;
            }
            // check for either of them == to null
            if ((object) base1 == null || (object) base2 == null)
            {
                return false;
            }
            if (base1.Id == base2.Id)

            {
                return true;
            }
            return true;
        }

        /// < summary >
        /// Operator overload for determining inequality.
        /// </summary >
        /// < param name="base1" > The first instance of an
        /// < see cref="Entity"/> . </param >
        /// < param name="base2" > The second instance of an
        /// < see cref="Entity"/> . </param >
        /// < returns > True if not equal. </returns >
        public static
            bool operator !=(Entity base1,
                Entity base2)
        {
            return (!(
                base1 == base2));
        }

        /// < summary >
        /// Serves as a hash function for this type.
        /// </summary >
        /// < returns > A hash code for the current Key
        /// property. </returns >
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        #endregion

        #region Validate

        public virtual bool Validate()
        {
            return true;
        }

        #endregion
    }

    public enum State
    {
        Unchanged,
        Added,
        Modified,
        Deleted,
    }

}


 