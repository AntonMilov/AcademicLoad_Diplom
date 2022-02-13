using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /// <summary>
    /// Модель группы.
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Название группы.
        /// </summary>
        public string Name {get; set;}

        /// <summary>
        /// Кол-во студентов.
        /// </summary>
        public int Students { get; set; }
    }
}
