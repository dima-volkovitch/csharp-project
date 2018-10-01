
namespace ProjectManagementSystem.Entity
{
    public class Business
    {
        protected long UserId { get; set; }

        protected long ProjectId { get; set; }

        public User User { get; set; }

        public Project Project { get; set; }

        public double EmploymentPercentage { get; set; }
    }
}
