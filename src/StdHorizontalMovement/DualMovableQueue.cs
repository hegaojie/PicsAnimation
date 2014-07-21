using System;
using System.Collections.Generic;
using System.Linq;

namespace StdHorizontalMovement
{
    public class DualMovableQueue<T> where T : IComparable, new()
    {
        private readonly IList<T> _elements;
        private readonly IList<T> _visibleElements;
        private readonly int _visibleCount;
        private int _visibleWinStart;
        private int _visibleWinEnd;

        public DualMovableQueue(int visibleCount)
        {
            _elements = new List<T>();
            _visibleElements = new List<T>(visibleCount);
            _visibleCount = visibleCount;
            InitVisibleWinIndex();
        }

        private void InitVisibleWinIndex()
        {
            _visibleWinStart = -1;
            _visibleWinEnd = -1;
        }

        public int Count { get { return _elements.Count; } }
        public int VisibleCount { get { return _visibleElements.Count; } }
        public IEnumerable<T> VisibleElements { get { return _visibleElements; } }

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
            if (_visibleElements.Count < _visibleCount)
            {
                _visibleElements.Add(element);
                _visibleWinEnd++;

                if (_visibleWinStart < 0)
                    _visibleWinStart++;
            }
        }

        public void Clear()
        {
            _visibleElements.Clear();
            InitVisibleWinIndex();

            _elements.Clear();
        }

        public void Move2Left()
        {
            if (CanMove2Left)
            {
                _visibleElements.Add(_elements[++_visibleWinEnd]);
                _visibleElements.RemoveAt(0);
                _visibleWinStart++;
            }
        }

        private bool CanMove2Left
        {
            get
            {
                return _elements.LastOrDefault().CompareTo(_visibleElements.LastOrDefault()) != 0;
            }
        }

        public void Move2First()
        {
            if (CanMove2Right)
            {
                _visibleElements.Clear();

                for (var i = 0; i < _visibleCount; i++)
                    _visibleElements.Add(_elements[i]);
                
                _visibleWinEnd = _visibleCount - 1;
                _visibleWinStart = 0;
            }
        }

        public void Move2Right()
        {
            if (CanMove2Right)
            {
                _visibleElements.RemoveAt(VisibleCount - 1);
                _visibleElements.Insert(0, _elements[--_visibleWinStart]);
                _visibleWinEnd--;
            }
        }

        private bool CanMove2Right
        {
            get
            {
                return _elements.FirstOrDefault().CompareTo(_visibleElements.FirstOrDefault()) != 0;
            }
        }

        public void Move2Last()
        {
            if (CanMove2Left)
            {
                _visibleElements.Clear();

                for (var i = 0; i < _visibleCount; i++)
                    _visibleElements.Insert(0, _elements[_elements.Count - 1 - i]);

                _visibleWinEnd = _elements.Count - 1;
                _visibleWinStart = _elements.Count - _visibleCount;
            }
        }
    }
}
