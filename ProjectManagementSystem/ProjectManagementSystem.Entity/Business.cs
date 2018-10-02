
namespace ProjectManagementSystem.Model
{
    public class Business
    {
        public long UserId { get; set; }

        public long ProjectId { get; set; }

        public virtual User User { get; set; }

        public virtual Project Project { get; set; }

        public double EmploymentPercentage { get; set; }
    }
}
