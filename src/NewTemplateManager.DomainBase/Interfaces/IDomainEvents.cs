
using NewTemplateManager.DomainBase;


namespace NewTemplateManager.DomainBase.Interfaces
{
    public interface IDomainEvents
    {
        IReadOnlyList<BaseDomainEvent> DomainEvents { get; }
        void AddDomainEvent(BaseDomainEvent domainEvent);
        void RemoveDomainEvent(BaseDomainEvent domainEvent);
        void AddDomainEvents(IEnumerable<BaseDomainEvent> domainEvents);
        void RemoveDomainEvents(IEnumerable<BaseDomainEvent> domainEvents);
        void ClearDomainEvents();

    }
}
