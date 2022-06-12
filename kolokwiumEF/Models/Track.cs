using System;
using System.Collections.Generic;

namespace kolokwium_s22006.Models
{
    public class Track
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public int IdMusicAlbum { get; set; }
        public virtual Album Album { get; set; }
        public virtual ICollection<Musician_Track> Musician_Track { get; set; }
    }
}
