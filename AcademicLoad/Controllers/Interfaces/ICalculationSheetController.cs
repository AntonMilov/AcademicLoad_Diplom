﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace AcademicLoadModule.Controllers.Interfaces
{
    /// <summary>
    /// Интерфейс контроллера для расчетных листов кафедральной нагрузки.
    /// </summary>
    public interface ICalculationSheetController
    {
        /// <summary>
        /// Запросить у пользователя выбор файла расчетного листа кафедральной нагрузки.
        /// </summary>
        /// <returns>Путь к выбранному файлу.</returns>
        string AskExcelFile();

        /// <summary>
        /// Добавит расчетный лист кафедральной нагрузки.
        /// </summary>
        void AddCalculationSheet(string path);

        /// <summary>
        /// Добавит расчетный лист кафедральной нагрузки.
        /// </summary>
        CalculationSheet CalculationSheet { get; set; }
    }
}
