using System.Collections.Generic;

namespace Core.Model
{
    public class Reservation
    {
        // rasmus var her
        public long ReservationId { get; set; } //PK
        public long UserId { get; set; }
        public Show Show { get; set; }
        public List<Seat> Seats { get; set; }
        public long ShowId { get; set; }
    }
}
