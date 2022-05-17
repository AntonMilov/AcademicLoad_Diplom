using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Photo
{
    /// <summary>
    /// Реализация <see cref="IPhotoService"/>
    /// </summary>
    public class PhotoService : IPhotoService
    {
        private string directoryPath = $"{Environment.CurrentDirectory}\\Photos\\";

        public PhotoService()
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }


        /// <inheritdoc/>
        public string AddPhoto(string path)
        {
            FileInfo copiedPhoto;
            try
            {
          
                FileInfo photo = new FileInfo(path);
                copiedPhoto = photo.CopyTo(directoryPath + photo.Name, true);
            }
            catch (Exception e)
            {
                return null;
            }

            return copiedPhoto.FullName;
        }

        /// <inheritdoc/>
        public void DeletePhoto(string path)
        {
            FileInfo photo = new FileInfo(path);
            photo.Delete();
        }
    }
}
