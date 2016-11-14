using System;

namespace Bigly.Infrastructure.DomainBase
{
    public abstract class ValueObject<T>: IEquatable<T> where T:ValueObject<T>
    {
        public abstract bool Equals(T other);
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();

    }
}
