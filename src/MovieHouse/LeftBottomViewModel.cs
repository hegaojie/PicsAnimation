using Caliburn.PresentationFramework;
using Caliburn.PresentationFramework.ApplicationModel;

namespace MovieHouse
{
    public class LeftBottomViewModel : PropertyChangedBase, IHandle<TextEvent>
    {
        private IEventAggregator _eventAggregator;

        public LeftBottomViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set 
            { 
                _text = value;
                NotifyOfPropertyChange(() => Text);
            }
        }

        public void Handle(TextEvent message)
        {
            Text = message.Text;
        }
    }

    public class TextEvent
    {
        public string Text { get; set; }
    }
}