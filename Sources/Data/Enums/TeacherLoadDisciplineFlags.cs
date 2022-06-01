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
        IsNotLecture = 0x0001 << 3,

        /// <summary>
        /// По данной дисциплине есть  зачет или зачет с оценкой.
        /// </summary>
        NasTest = 0x0001 << 4,

        /// <summary>
        /// По данной дисциплине есть экзамен.
        /// </summary>
        NasExam = 0x0001 << 5,

        /// <summary>
        /// По данной дисциплине есть курсовой проект.
        /// </summary>
        NasKp = 0x0001 << 6,

        /// <summary>
        /// По данной дисциплине есть курсовая работа.
        /// </summary>
        NasKr = 0x0001 << 7,

              /// <summary>
              /// По данной дисциплине есть лабораторные рабоыт.
              /// </summary>
        HasLab= 0x0001 << 8
    }
}
