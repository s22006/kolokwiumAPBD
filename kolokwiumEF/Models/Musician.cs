using System.Collections.Generic;

namespace kolokwium_s22006.Models
{
    public class Musician
    {
        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Nickname { get; set; }
        public virtual ICollection<Musician_Track> Musician_Track { get; set; }
    }
}
