
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
        /// Кол-во студентов.
        /// </summary>
        public int Students { get; set; }
    }
}
