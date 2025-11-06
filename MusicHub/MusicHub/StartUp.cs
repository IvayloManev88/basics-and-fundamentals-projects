namespace MusicHub
{
    using Data;
    using Initializer;
    using MusicHub.Data.Models;
    using System;
    using System.Diagnostics.Metrics;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            const int producerId = 9;
            const int seconds = 480;
            Console.WriteLine(ExportSongsAboveDuration(context, seconds));

        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(p => p.ProducerId.HasValue &&
                p.ProducerId.Value == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer!.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            SongPrice = s.Price.ToString("f2"),
                            SognWriter = s.Writer.Name,

                        }).OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.SognWriter)
                        .ToArray(),
                    AlbumPrice = a.Price


                })
                .ToArray();
            albums = albums.OrderByDescending(a => a.AlbumPrice)
                .ToArray();    
            StringBuilder sb = new StringBuilder();
            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");
                int counter = 1;
                foreach (var song in  album.Songs)
                {
                    sb.AppendLine($"---#{counter}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.SongPrice}");
                    sb.AppendLine($"---Writer: {song.SognWriter}");
                    counter++;
                }
                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();
            TimeSpan durationTs = TimeSpan.FromSeconds(duration);
            var songsAboveDuration = context.Songs.Where(s=>s.Duration> durationTs).AsEnumerable()
                .Select(s => new
                {
                    SongName = s.Name,
                    Performers = s.SongPerformers.Select(p => new { p.Performer.FirstName, p.Performer.LastName }).OrderBy(s => s.FirstName).ThenBy(s => s.LastName).ToArray(),
                    Writer = s.Writer.Name,
                    Producer = s.Album?.Producer?.Name ?? null,
                    Duration = s.Duration.ToString("c")


                }).OrderBy(s => s.SongName).ThenBy(s => s.Writer).ToArray();
           int counter = 1;
            foreach (var song in songsAboveDuration)
            {
                sb.AppendLine($"-Song #{counter}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.Writer}");
                foreach (var performer in song.Performers)
                {
                    sb.AppendLine($"---Performer: {performer.FirstName} {performer.LastName}");
                }
                if (song.Producer != null) sb.AppendLine($"---AlbumProducer: {song.Producer}");
                
                sb.AppendLine($"---Duration: {song.Duration}");
                counter++;
            }
            return sb.ToString().TrimEnd();

        }

        
    }
}
