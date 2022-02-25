

using Prism.Events;

namespace AcademicLoadModule.Events
{
    /// <summary>
    /// Событие изменения количества учебных групп.
    /// </summary>
    public class GroupsCountChangeEvent : PubSubEvent<int>
    {
    }
}
