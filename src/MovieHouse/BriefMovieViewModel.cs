using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace MovieHouse
{
    public class BriefMovieViewModel : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PosterFileName { get; set; }
        public BitmapImage Poster { get; set; }

        public double CanvasTop { get; set; }
        public double CanvasLeft { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Opacity { get; set; }

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
            return Id == ((BriefMovieViewModel)obj).Id ? 0 : -1;
        }
    }
}