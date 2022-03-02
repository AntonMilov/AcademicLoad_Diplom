using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Json.Interfaces;
using Data.Models;
using Newtonsoft.Json;

namespace Core.Json
{
    /// <summary>
    /// <see cref="IJsonExporter"/>.
    /// </summary>
    public class JsonImporter : IJsonImporter
    {
        private readonly PathConstants pathConstants;
       
        /// <summary>
        /// ctor.
        /// </summary>
        public JsonImporter()
        {
            pathConstants = new PathConstants();
        }

        public List<Group> LoadGroups()
        {
            using (FileStream file = new FileStream(pathConstants.PathJsonGroups, FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    var json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Group>>(json) ?? new List<Group>();
                }
            }
        }

        public List<Teacher> LoadTeachers()
        {
            using (FileStream file = new FileStream(pathConstants.PathJsonTeachers, FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    var json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<Teacher>>(json) ?? new List<Teacher>();
                }
            }
        }
    }
}
