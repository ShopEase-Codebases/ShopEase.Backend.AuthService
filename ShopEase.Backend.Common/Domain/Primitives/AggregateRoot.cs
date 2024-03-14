namespace ShopEase.Backend.Common.Domain.Primitives
{
    /// <summary>
    /// Base Class for Aggregate Roots
    /// </summary>
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot(Guid id) 
            : base(id)
        {
        }
    }
}
