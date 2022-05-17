using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Photo
{
    /// <summary>
    /// Интерфейс для работы с фотографиями.
    /// </summary>
    public interface IPhotoService
    {
        /// <summary>
        /// Добавление фотографии.
        /// </summary>
        /// <param name="path">путь.</param>
        /// <returns>Путь к перемещенной фотографии.</returns>
         string AddPhoto(string path);

        /// <summary>
        /// Удаление фотографии
        /// </summary>
        /// <param name="path">.</param>
         void DeletePhoto(string path);
    }
}
