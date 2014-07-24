using System.Windows.Controls;

namespace MovieHouse
{
    public class MvItemsControl : ItemsControl
    {
        protected override System.Windows.DependencyObject GetContainerForItemOverride()
        {
            return new BriefMovieViewContainer();
        }
    }
}