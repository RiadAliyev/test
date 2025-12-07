using Domain.common;

namespace Domain.Entities
{
    public class Tour : BaseEntyti
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public ICollection<TourActivity> TourActivities { get; set; }
    }
}
