using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace MovieHouse
{
    public class Movie : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PosterFileName { get; set; }
        public BitmapImage Poster { get; set; }

        public void LoadPoster()
        {
            if (File.Exists(PosterFileName))
                Poster = new BitmapImage(new Uri(PosterFileName));
            else
            {
                //TODO: load default poster
            }
        }

        public int CompareTo(object obj)
        {
            return Id == ((Movie) obj).Id ? 0 : -1;
        }
    }
}