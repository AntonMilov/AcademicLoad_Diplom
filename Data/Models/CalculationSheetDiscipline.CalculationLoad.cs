using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /// <summary>
    /// Сущности для строк в таблице расчетного листа кафедральной нагрузки.
    /// </summary>
    public partial class CalculationSheetDiscipline
    {
        public List<TeacherLoadDiscipline> TeacherLoadDisciplines;
    }
}
