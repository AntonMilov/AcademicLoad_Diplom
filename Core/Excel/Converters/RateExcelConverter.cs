using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Excel.Converters
{
    /// <summary>
    /// Конвертор для конвертация Rate в соотвутсвуещие название или значение Double.
    /// </summary>
    public class RateExcelConverter
    {
        /// <inheritdoc/>
        public object Convert(object value)
        {
            Rate rate = (Rate)value;

            switch (rate)
            {
                case Rate.Rate25:
                    return "25";

                case Rate.Rate50:
                    return "50";

                case Rate.Rate75:
                    return "75";

                case Rate.Rate100:
                    return "100";

                case Rate.RateHourly:
                    return "Почасовая";

                default:
                    return "";
            }
        }

        /// <inheritdoc/>
        public object ConvertBack(object value)
        {
            throw new NotImplementedException();
        }
    }
}
