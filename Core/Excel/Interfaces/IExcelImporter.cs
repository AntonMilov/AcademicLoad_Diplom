﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Core.Excel.Interfaces
{
    /// <summary>
    /// Интерфейс для экспорта Excel.
    /// </summary>
    public interface IExcelImporter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        CalculationSheet ImportCalculationSheet(string path);
    }
}
