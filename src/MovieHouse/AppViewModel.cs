using Caliburn.PresentationFramework;
using Caliburn.PresentationFramework.ApplicationModel;

namespace MovieHouse
{
    public class AppViewModel : PropertyChangedBase
    {
        public AppViewModel(HeaderViewModel header, 
                            ScrollerViewModel scroller, 
                            LeftBottomViewModel left, 
                            RightBottomViewModel right)
        {
            Header = header;
            Scroller = scroller;
            Left = left;
            Right = right;
        }

        public HeaderViewModel Header { get; set; }

        public ScrollerViewModel Scroller { get; set; }

        public LeftBottomViewModel Left { get; set; }

        public RightBottomViewModel Right { get; set; }
    }
}