using System.Diagnostics.CodeAnalysis;

namespace Domain.SharedKernel
{
    public abstract class Entity
    {
        private int? _requestedHashCode;
        public virtual int Id { get; protected set; }

        public bool IsTransient()
        {
            return Id == default;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            var item = (Entity)obj;

            if (item.IsTransient() || IsTransient())
                return false;

            return item.Id == Id;
        }

        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")] // EF requires Id to be non readonly
        public override int GetHashCode()
        {
            if (IsTransient())
                return 0;

            if (!_requestedHashCode.HasValue)
                _requestedHashCode = Id.GetHashCode() ^ 31;

            return _requestedHashCode.Value;

        }
        public static bool operator ==(Entity left, Entity right)
        {
            return left?.Equals(right) ?? Equals(right, null);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}
