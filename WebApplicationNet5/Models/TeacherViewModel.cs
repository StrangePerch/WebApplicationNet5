using WebApplicationNet5.Entities.School;

namespace WebApplicationNet5.Models
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }

        public TeacherViewModel FromModel(Teacher model)
        {
            Id = model.Id;
            Name = model.Name;
            Group = model.Group != null ? model.Group.Name : "No group";
            return this;
        }
        
        public void ToModel(Teacher model)
        {
            model.Id = Id;
            model.Name = Name;
        }

        public Teacher ToModel()
        {
            var teacher = new Teacher();
            ToModel(teacher);
            return teacher;
        }
    }
}