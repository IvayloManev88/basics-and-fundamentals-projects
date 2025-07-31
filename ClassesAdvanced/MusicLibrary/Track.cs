namespace MusicLibrary
{
    public class Track
    {
        public Track(string title, string artist, int duration, string genre)
        {
            Title = title;
            Artist = artist;
            Duration = duration;
            Genre = genre;
        }

        public string Title { get; set; }
        public string Artist { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }

        public override string ToString() => $"Track: '{this.Title}' by {this.Artist} - {this.Duration}s [{this.Genre}]";
       
    }
}
