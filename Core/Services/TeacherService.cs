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
            Teachers = jsonImporter.LoadTeachers();

            this.jsonImporter = jsonImporter;
            this.jsonExporter = jsonExporter;
        }

        public List<Teacher> Teachers
        {
            get => teachers;
            set => teachers = value;
        }

        public void AddTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);

            jsonExporter.SaveTeachers(Teachers);
        }
    }
}
