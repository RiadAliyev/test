namespace Domain.Entities
{
    public class TourActivity
    {
        public int TourId { get; set; }
        public Tour Tour { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
