
namespace Data.Models
{
    /// <summary>
    /// Модель учебной группы.
    /// </summary>
    public class Group
    {
        private string name;

        /// <summary>
        /// Название группы.
        /// </summary>
        public string Name
        {
            get => name;
            set => name = value.ToUpper();

        }

        /// <summary>
        /// Всего студентов.
        /// </summary>
        public int Students => StudentsBudget + StudentsContract;

        /// <summary>
        /// Количество студентов на бюджетной основе.
        /// </summary>
        public int StudentsBudget { get; set; }

        /// <summary>
        /// Количество студентов на договорной основе.
        /// </summary>
        public int StudentsContract { get; set; }
    }
}
