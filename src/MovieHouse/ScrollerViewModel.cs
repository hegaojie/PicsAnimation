using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Data;
using Caliburn.PresentationFramework;
using StdHorizontalMovement;

namespace MovieHouse
{
    public class ScrollerViewModel : PropertyChangedBase
    {
        public ObservableCollection<BriefMovieViewModel> Posters { get { return _movies.VisibleElements; } }

        private readonly AnimateDualMovableQueue<BriefMovieViewModel> _movies; 

        public ScrollerViewModel()
        {
            _movies = new AnimateDualMovableQueue<BriefMovieViewModel>(7);

            for (var i = 1; i <= 7; i++)
            {
                var movie = new BriefMovieViewModel { Id = i, Name = "M" + i, PosterFileName = @"D:\git_repository\PicsAnimation\src\pics\p" + i + ".png" };
                movie.LoadPoster();
                movie.Width = 80;
                movie.Height = 120;
                movie.CanvasTop = 0;
                movie.CanvasLeft = 80*(i - 1);
               
                _movies.Append(movie);
            }

            
        }
        
        public void MoveLeft()
        {
            _movies.Move2Left();
            NotifyOfPropertyChange(() => CanMoveLeft);
            NotifyOfPropertyChange(() => CanMoveRight);

            //TODO: animation

        }
        
        public bool CanMoveLeft { 
            get { return _movies.CanMove2Left; }
        }
        
        public void MoveRight()
        {
            _movies.Move2Right();
            NotifyOfPropertyChange(() => CanMoveLeft);
            NotifyOfPropertyChange(() => CanMoveRight);
        }

        public bool CanMoveRight {
            get { return _movies.CanMove2Right; }
        }
    }

    public class AnimateDualMovableQueue<T> : DualMovableQueue<T> where T : IComparable, new()
    {
        public AnimateDualMovableQueue(int visiableCount) : base(visiableCount)
        {
        }

        public void Move2Left()
        {
            //TODO: ANIMATION
            double nextCanvasLeft = 0;
            foreach (var visibleElement in VisibleElements)
            {
                nextCanvasLeft = visibleElement.NextCanvasLeft;
                
            }



            base.Move2Left();
        }
    }

}