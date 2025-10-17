using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data
{
    public static class EntityValidationConstants
    {
        public static class Song
        {
            public const int SongNameMaxLength = 20;
        }

        public static class Album
        {
            public const int AlbumNameMaxLength = 40;
        }

        public static class Performer
        {
            public const int FirstNameMaxLength = 20;
            public const int LastNameMaxLength = 20;
        }

        public static class Producer
        {
            public const int ProducerNameMaxLength = 20;
        }

        public static class Writer
        {
            public const int WriterNameMaxLength = 20;
        }
    }
}
