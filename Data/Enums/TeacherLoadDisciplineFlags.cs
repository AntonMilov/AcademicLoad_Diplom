using System;


namespace Data.Enums
{
    /// <summary>
    /// Флаги для назначения преподавателя к  дисциплине.
    /// </summary>
    [Flags]
    public enum TeacherLoadDisciplineFlags
    {
        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        None = 0x0001,

        /// <summary>
        /// Назначения для основного лектора.
        /// </summary>
        IsMainLecture = 0x0001 << 1,

        /// <summary>
        /// Назначение для дополнительного лектора.
        /// </summary>
        IsAdditionalLecture = 0x0001 << 2,

        /// <summary>
        /// Назначения для преподавателя, который не является лектором.
        /// </summary>
        IsNotLecture = 0x0001 << 3
    }
}
