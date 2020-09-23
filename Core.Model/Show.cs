using System;

namespace Core.Model
{
    public class Show
    {
        public long ShowId { get; set; }
        public short HallId { get; set; }
        public long MovieId { get; set; }
        public DateTime Data { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
