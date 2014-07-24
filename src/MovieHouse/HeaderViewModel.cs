using System.Dynamic;
using System.Windows;
using Caliburn.PresentationFramework;
using Caliburn.PresentationFramework.ApplicationModel;

namespace MovieHouse
{
    public class HeaderViewModel : PropertyChangedBase
    {
        private readonly IEventAggregator _eventAggregator;
        private IWindowManager _windowManager;

        private int _counter = 0;

        public HeaderViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
        }

        public void ChangeText()
        {
            _eventAggregator.Publish(new TextEvent { Text = "Click" + (++_counter) });
        }

        public void OpenWindow()
        {
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.Manual;
            settings.Title = "Example";

            _windowManager.ShowWindow(new AppViewModel(new HeaderViewModel(_eventAggregator, _windowManager),
                                                       new ScrollerViewModel(), 
                                                       new LeftBottomViewModel(_eventAggregator),
                                                       new RightBottomViewModel()));

            
        }
    }
}