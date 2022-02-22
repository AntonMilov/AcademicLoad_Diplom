using System;
using System.Collections.Generic;
using System.Linq;
using Core.Services.Interfaces;
using Data.Models;
using Prism.Events;

namespace Core.Services
{
    /// <summary>
    /// <see cref="ITeacherService"/>
    /// </summary>
    public class TeacherService : ITeacherService
    {
        private ICollection<Teacher> teachers;

        /// <summary>
        /// .ctor
        /// </summary>
        public TeacherService()
        {
            teachers = new List<Teacher>();
        }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Teacher> Teachers
        {
            get => teachers;
            set => teachers = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacher"></param>
        public void AddTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);
        }
    }
}
