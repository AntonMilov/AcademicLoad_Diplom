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
    public class JsonExporter : IJsonExporter
    {
        private readonly PathConstants pathConstants;
        private readonly JsonSerializer jsonSerializer;

        /// <summary>
        /// ctor.
        /// </summary>
        public JsonExporter()
        {
            jsonSerializer = new JsonSerializer();
            pathConstants = new PathConstants();
        }

        public void SaveGroups(List<Group> groups)
        {
            using (FileStream file = new FileStream(pathConstants.PathJsonGroups, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    jsonSerializer.Serialize(writer, groups);
                }
            }
        }

        public void SaveTeachers(List<Teacher> groups)
        {
            using (FileStream file = new FileStream(pathConstants.PathJsonTeachers, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    jsonSerializer.Serialize(writer, groups);
                }
            }
        }
    }
}
