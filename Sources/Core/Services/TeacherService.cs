using System;
using System.Collections.Generic;
using System.Linq;
using Core.Json.Interfaces;
using Core.Services.Interfaces;
using Data.Models;

namespace Core.Services
{
    /// <summary>
    /// <see cref="ITeacherService"/>
    /// </summary>
    public class TeacherService : ITeacherService
    {
        private readonly IJsonImporter jsonImporter;
        private readonly IJsonExporter jsonExporter;
        private List<Teacher> teachers;

        /// <summary>
        /// .ctor
        /// </summary>
        public TeacherService(IJsonImporter jsonImporter, IJsonExporter jsonExporter)
        {
            this.jsonImporter = jsonImporter;
            this.jsonExporter = jsonExporter;

            Teachers = jsonImporter.LoadTeachers();
            jsonImporter = null;
        }

        /// <inheritdoc/>
        public List<Teacher> Teachers
        {
            get => teachers;
            set => teachers = value;
        }

        /// <inheritdoc/>
        public void AddTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);

            jsonExporter.SaveTeachers(Teachers);
        }

        /// <inheritdoc/>
        public void DeleteTeacher(Teacher teacher)
        {
            Teachers.Remove(teacher);

            jsonExporter.SaveTeachers(Teachers);
        }

        /// <inheritdoc/>
        public void SaveEditTeacher()
        {
            jsonExporter.SaveTeachers(Teachers);
        }
    }
}
