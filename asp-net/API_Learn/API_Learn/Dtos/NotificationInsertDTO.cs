namespace DSLearn.Dtos
{
    public class NotificationInsertDTO
    {
        public string Text { get; set; }
        public DateTime Moment { get; set; }
        public bool Read { get; set; } = false;
        public string Route { get; set; }

        public string UserId { get; set; }
    }
}
