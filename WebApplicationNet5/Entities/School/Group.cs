using System.Collections.Generic;

namespace WebApplicationNet5.Entities.School
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student> Students { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}