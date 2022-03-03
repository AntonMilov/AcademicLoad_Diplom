using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Json
{
    /// <summary>
    /// Пути для JSON файлов.
    /// </summary>
    public class PathConstants
    {
        /// <summary>
        /// Путь к файла групп.
        /// </summary>
        public string PathJsonGroups = $"{Environment.CurrentDirectory}/JsonGroups.json";

        /// <summary>
        /// Путь к файле преподавателей.
        /// </summary>
        public string PathJsonTeachers= $"{Environment.CurrentDirectory}/JsonTeachers.json";
    }
}
