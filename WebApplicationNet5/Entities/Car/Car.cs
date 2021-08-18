namespace WebApplicationNet5.Entities.Car
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int DrivetrainId {get; set; }
        public Drivetrain Drivetrain {get; set; }
        
        public int ModelId {get; set; }
        public Model Model {get; set; }
    }
}