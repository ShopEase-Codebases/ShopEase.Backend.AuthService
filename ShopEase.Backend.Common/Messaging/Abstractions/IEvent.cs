using MediatR;

namespace ShopEase.Backend.Common.Messaging.Abstractions
{
    /// <summary>
    /// Marker Interface to Reperesent an Event
    /// </summary>
    public interface IEvent : INotification
    {
    }
}
