using System.Collections.Generic;

namespace Core.Model
{
    public class User
    {
        public long Id { get; set; } //PK

        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public MovieGenre PerforemGenre { get; set; }
        public List<Reservation> Reservations { get; set; } = null;
    }
}
