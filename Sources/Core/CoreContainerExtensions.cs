using Core.Excel;
using Core.Excel.Interfaces;
using Core.Json;
using Core.Json.Interfaces;
using Core.Services;
using Core.Services.Interfaces;
using Prism.Ioc;

namespace Core
{
    /// <summary>
    /// Класс расширений для регистрации Core.
    /// </summary>
    public static class CoreContainerExtensions
    {
        /// <summary>
        /// Расширение IContainerRegistry для  регистрации для Core.
        /// </summary>
        /// <param name="containerRegistry"></param>
        public static void RegisterCore(this IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IExcelExporter, ExcelExporter>();
            containerRegistry.Register<IExcelImporter, ExcelImporter>();
            containerRegistry.Register<IJsonImporter, JsonImporter>();
            containerRegistry.Register<IJsonExporter, JsonExporter>();

            containerRegistry.RegisterSingleton<ITeacherService, TeacherService>();
            containerRegistry.RegisterSingleton<IGroupService, GroupService>();
            containerRegistry.RegisterSingleton<ICalculationSheetService, CalculationSheetService>();
            containerRegistry.RegisterSingleton<ITeacherLoadDisciplineService, TeacherLoadDisciplineService>();
        }
    }
}
