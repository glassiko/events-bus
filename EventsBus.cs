using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace DIY
{
    /// <summary>
    ///    Represents a dictionary with events, aggregating publishers and subscribers.
    /// </summary>
    public class EventsBus
    {
        private ConcurrentDictionary<Type, IList> _events = new ConcurrentDictionary<Type, IList>();

		/// <summary>
		///    Adds subscriber to a chain of event handlers.
		/// </summary>
        public void Subscribe<TEvent>(Action<TEvent> handler)
        {
            var handlers = GetOrAdd<TEvent>();
            handlers.Add(handler);
        }

		/// <summary>
		///    Triggers all subscribers of a given event.
		/// </summary>
        public void Publish<TEvent>(TEvent e)
        {
            var handlers = GetOrAdd<TEvent>();
            foreach (var handler in handlers)
            {
                handler(e);
            }
        }

		/// <summary>
		///    Returns a list of event-handlers.
		/// </summary>
        private List<Action<TEvent>> GetOrAdd<TEvent>()
        {
            var handlers = _events.GetOrAdd(typeof(TEvent), _ => new List<Action<TEvent>>());
            return handlers as List<Action<TEvent>>;
        }
    }
}
