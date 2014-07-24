using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;

namespace Foo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public IList<Person> Items { get; set; }

        public MyCollection<Person> Items { get; set; }


        private IList<Person> _items;

        public MainWindow()
        {
            InitializeComponent();

            _items = new List<Person>();
            _items.Add(new Person(){Name = "N1", Address = "A1"});
            _items.Add(new Person(){Name = "N2", Address = "A2"});

            Items = new MyCollection<Person>(_items);

            DataContext = this;
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            _items.Add(new Person(){Name = "N3", Address = "A3"});
            Items.RaiseCollectionChanged();
        }

        private void BtnRemove_OnClick(object sender, RoutedEventArgs e)
        {
            _items.RemoveAt(2);
        }
    }

    public class MyCollection<T> : List<T>, INotifyCollectionChanged
    {
        public MyCollection(IList<T> list) : base(list)
        {
            
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void RaiseCollectionChanged()
        {
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
