// -----------------------------------------------------------------------
// <copyright file="StrokeChangedEvent.cs" company="John">
//  Scribble: A WPF Sample application 
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Infrastructure.Events
{
    using Microsoft.Practices.Prism.Events;

    /// <summary>
    /// StrokeChangedEvent class
    /// </summary>
    public class StrokeChangedEvent : CompositePresentationEvent<int> { }
}
