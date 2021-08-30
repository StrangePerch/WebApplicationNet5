using WebApplicationNet5.Entities.School;

namespace WebApplicationNet5.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public StudentViewModel FromModel(Student model)
        {
            Id = model.Id;
            Name = model.Name;
            GroupId = model.GroupId;
            GroupName = model.Group.Name;
            return this;
        }
        
        public void ToModel(Student model)
        {
            model.Id = Id;
            model.Name = Name;
            model.GroupId = GroupId;
        }

        public Student ToModel()
        {
            var student = new Student();
            ToModel(student);
            return student;
        }
    }
}