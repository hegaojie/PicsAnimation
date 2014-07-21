using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using StdHorizontalMovement;


namespace PicsAnimationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public ObservableCollection<ObjectSample> Objects
        {
            get
            {
                IEnumerable<ObjectSample> ret = _queue.VisibleElements;
                if (ret != null)
                    return new ObservableCollection<ObjectSample>(ret);
                return null;
            }
        } 

        public int Counter { get { return _queue.Count; } }

        private DualMovableQueue<ObjectSample> _queue;

        private int counter = 0;

        public MainWindow()
        {
            InitializeComponent();
            _queue = new DualMovableQueue<ObjectSample>(5);
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UxMove2Left_OnClick(object sender, RoutedEventArgs e)
        {
            _queue.Move2Left();
            OnPropertyChanged("Objects");
        }

        private void UxMove2Right_OnClick(object sender, RoutedEventArgs e)
        {
            _queue.Move2Right();
            OnPropertyChanged("Objects");
        }

        private void UxAppend_OnClick(object sender, RoutedEventArgs e)
        {
            _queue.Append(new ObjectSample { Description = "Object " + (++counter) });
            if (_queue.VisibleCount <= 5)
            {
                OnPropertyChanged("Objects");
            }

            OnPropertyChanged("Counter");
        }

        private void UxMove2First_OnClick(object sender, RoutedEventArgs e)
        {
            _queue.Move2First();
            OnPropertyChanged("Objects");
        }

        private void UxMove2Last_OnClick(object sender, RoutedEventArgs e)
        {
            _queue.Move2Last();
            OnPropertyChanged("Objects");
        }
    }

    public class ObjectSample : IComparable
    {
        public string Description { get; set; }

        public int CompareTo(object obj)
        {
            return this == obj ? 0 : -1;
        }
    }
}
