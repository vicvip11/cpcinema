using System.Collections.Generic;

namespace Core.Model
{
    public class Hall
    {
        public short HallId { get; set; } //PK
        public List<Seat> Seats { get; set; }
    }
}
