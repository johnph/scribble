// -----------------------------------------------------------------------
// <copyright file="ToolChangedEvent.cs" company="John">
//  Scribble: A WPF Sample application 
// </copyright>
// -----------------------------------------------------------------------

namespace John.Scribble.Infrastructure.Events
{
    using John.Scribble.Infrastructure.Enums;
    using Microsoft.Practices.Prism.Events;

    /// <summary>
    /// ToolChangedEvent class
    /// </summary>
    public class ToolChangedEvent : CompositePresentationEvent<DrawingMode> { }
}
