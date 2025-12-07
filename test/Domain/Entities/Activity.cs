using Domain.common;

namespace Domain.Entities
{
    public class Activity : BaseEntyti
    {
        public string Name { get; set; }

        public ICollection<TourActivity> TourActivities { get; set; }
    }
}
