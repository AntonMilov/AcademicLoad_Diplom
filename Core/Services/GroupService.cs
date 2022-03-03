using System.Collections.Generic;
using Core.Json.Interfaces;
using Core.Services.Interfaces;
using Data.Models;

namespace Core.Services
{
    /// <summary>
    /// <see cref="IGroupService"/>
    /// </summary>
    public class GroupService : IGroupService
    {
        private readonly IJsonImporter jsonImporter;
        private readonly IJsonExporter jsonExporter;
        private List<Group> groups;
        
        /// <summary>
        /// ctor.
        /// </summary>
        public GroupService(IJsonImporter jsonImporter, IJsonExporter jsonExporter)
        {
            Groups = jsonImporter.LoadGroups();

            this.jsonImporter = jsonImporter;
            this.jsonExporter = jsonExporter;
        }
      
        public void AddGroup(Group group)
        {
            Groups.Add(group);
            
            jsonExporter.SaveGroups(Groups);
        }

        public void DeleteGroup(Group group)
        {
            groups.Remove(group);

            jsonExporter.SaveGroups(Groups);
        }

        public List<Group> Groups
        {
            get => groups;
            set => groups = value;
        }
    }
}
