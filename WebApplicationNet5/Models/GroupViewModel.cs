using System.Collections.Generic;
using WebApplicationNet5.Entities.School;

namespace WebApplicationNet5.Models
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // public List<Student> Students { get; set; }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        
        public GroupViewModel FromModel(Group model)
        {
            Id = model.Id;
            Name = model.Name;
            TeacherName = model.Teacher.Name;
            TeacherId = model.Teacher.Id;
            return this;
        }
        
        public void ToModel(Group model)
        {
            model.Id = Id;
            model.Name = Name;
            model.TeacherId = int.Parse(TeacherName);
        }

        public Group ToModel()
        {
            var group = new Group();
            ToModel(group);
            return group;
        }
    }
}