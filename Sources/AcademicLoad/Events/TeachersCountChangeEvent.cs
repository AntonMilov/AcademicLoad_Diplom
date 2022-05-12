using Prism.Events;

namespace AcademicLoadModule.Events
{
    /// <summary>
    /// Событие изменения количества преподавателей.
    /// </summary>
    public class TeachersCountChangeEvent : PubSubEvent<int>
    {
    }
}
