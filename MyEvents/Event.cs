namespace MyEvents
{
    public class Event
    {
        public string Name { get; }
        public string Type { get; }
        public int Capacity { get; private set; }
        public bool IsActive { get; private set; }

        public Event(string name, string type, int capacity)
        {
            Name = name;
            Type = type;
            Capacity = capacity;
            IsActive = true;
        }

        public void Cancel()
        {
            IsActive = false;
        }

        public bool RegisterAttendee()
        {
            if (IsActive && Capacity > 0)
            {
                Capacity--;
                return true;
            }
            return false;
        }

        private List<int> ratings = new List<int>();

        public double AverageRating()
        {
            return ratings.Count > 0 ? ratings.Average() : 0;
        }

        public bool AddRating(int rating)
        {
            if (rating < 1 || rating > 5)
            {
                return false; // Invalid rating, must be between 1 and 5
            }

            ratings.Add(rating);
            return true;
        }
    }
}