using System.Collections.Generic;

namespace kolokwium_s22006.Models
{
    public class MusicLabel
    {
        public int IdMusicLabel { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Album> Album { get; set; }
    }
}
