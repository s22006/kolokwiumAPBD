using System;
using System.Collections.Generic;

namespace kolokwium_s22006.Models.DTOs
{
    public class SomeKindOfAlbum
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public int IdMusicLabel { get; set; }
        public MusicLabel MusicLabel { get; set; }
        public IEnumerable<SomeKindOfTrack> Tracks { get; set; }
    }
}
