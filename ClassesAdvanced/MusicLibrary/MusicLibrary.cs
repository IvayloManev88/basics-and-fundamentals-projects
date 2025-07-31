using System.Text;

namespace MusicLibrary
{
    public class MusicLibrary
    {
        public MusicLibrary(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Tracks = new List<Track>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Track> Tracks { get; set; }

        public void AddTrack(Track track)
        {
            if (this.Capacity > this.Tracks.Count)
            {
                if (!this.Tracks.Any(t => t.Title == track.Title && t.Artist == track.Artist))
                {
                    this.Tracks.Add(track);
                }

            }
        }
        public bool RemoveTrack(string title, string artist)
        {
            Track removeTrack = this.Tracks.FirstOrDefault(t => t.Title == title && t.Artist == artist);
            if (removeTrack != null)
            {
                this.Tracks.Remove(removeTrack);
                return true;
            }
            return false;
        }
        public Track GetLongestTrack()
        {
            return this.Tracks.OrderByDescending(t => t.Duration).First();
        }

        public string GetTrackDetails(string title, string artist)
        {
            Track currentTrack = this.Tracks.FirstOrDefault(t => t.Title == title && t.Artist == artist);
            if (currentTrack != null)
            {
                return currentTrack.ToString();
            }
            return "Track not found!";

        }
        public int GetTracksCount()
        {
            return this.Tracks.Count;
        }

        public List<Track> GetTracksByGenre(string genre)
        {
            List<Track> tracksByGenre = new List<Track>();
            tracksByGenre = Tracks.Where(t => t.Genre == genre).OrderBy(t => t.Duration).ToList();
            return tracksByGenre;
        }
        public string LibraryReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Music Library: {this.Name}");
            sb.AppendLine($"Tracks capacity: {this.Capacity}");
            sb.AppendLine($"Number of tracks added: {Tracks.Count}");
            sb.AppendLine("Tracks:");
            foreach (var track in this.Tracks.OrderByDescending(t => t.Duration))
            {
                sb.AppendLine($"-{track.ToString()}");
            }
            return sb.ToString().Trim();
        }

    }
}
