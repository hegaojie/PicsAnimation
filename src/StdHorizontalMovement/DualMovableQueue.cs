using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace StdHorizontalMovement
{
    public class DualMovableQueue<T> where T : IComparable, new()
    {
        private readonly IList<T> _elements;
        
        private int _visibleCount;
        private int _visibleWinStart;
        private int _visibleWinEnd;

        public DualMovableQueue(int visibleCount)
        {
            _elements = new List<T>();
            VisibleElements = new ObservableCollection<T>();
            _visibleCount = visibleCount;
            ResetVisibleWinIndex();
        }

        private void ResetVisibleWinIndex()
        {
            _visibleWinStart = -1;
            _visibleWinEnd = -1;
        }

        public int Count { get { return _elements.Count; } }
        public int VisibleCount { get { return VisibleElements.Count; } }
        public ObservableCollection<T> VisibleElements { get; private set; }

        public void Append(T element)
        {
            if (!_elements.Contains(element))
            {
                _elements.Add(element);
                UpdateVisibleElements(element);
            }
        }

        private void UpdateVisibleElements(T element)
        {
            if (VisibleElements.Count < _visibleCount)
            {
                VisibleElements.Add(element);
                _visibleWinEnd++;

                if (_visibleWinStart < 0)
                    _visibleWinStart++;
            }
        }

        public void Clear()
        {
            VisibleElements.Clear();
            ResetVisibleWinIndex();

            _elements.Clear();
        }

        public void Move2Left()
        {
            if (CanMove2Left)
            {
                VisibleElements.Add(_elements[++_visibleWinEnd]);
                VisibleElements.RemoveAt(0);
                _visibleWinStart++;
            }
        }

        public bool CanMove2Left
        {
            get
            {
                return _elements.LastOrDefault().CompareTo(VisibleElements.LastOrDefault()) != 0;
            }
        }

        public void Move2First()
        {
            if (CanMove2Right)
            {
                VisibleElements.Clear();

                for (var i = 0; i < _visibleCount; i++)
                    VisibleElements.Add(_elements[i]);

                _visibleWinEnd = _visibleCount - 1;
                _visibleWinStart = 0;
            }
        }

        public void Move2Right()
        {
            if (CanMove2Right)
            {
                VisibleElements.RemoveAt(VisibleCount - 1);
                VisibleElements.Insert(0, _elements[--_visibleWinStart]);
                _visibleWinEnd--;
            }
        }

        public bool CanMove2Right
        {
            get
            {
                return _elements.FirstOrDefault().CompareTo(VisibleElements.FirstOrDefault()) != 0;
            }
        }

        public void Move2Last()
        {
            if (CanMove2Left)
            {
                VisibleElements.Clear();

                for (var i = 0; i < _visibleCount; i++)
                    VisibleElements.Insert(0, _elements[_elements.Count - 1 - i]);

                _visibleWinEnd = _elements.Count - 1;
                _visibleWinStart = _elements.Count - _visibleCount;
            }
        }

        public void Move2LeftByStep(int steps)
        {
            for (var i = steps; i > 0; i--)
                Move2Left();
        }

        public void Move2RightByStep(int steps)
        {
            for (var i = steps; i > 0; i--)
                Move2Right();
        }
    }


}
