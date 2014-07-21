using System.Linq;
using StdHorizontalMovement;
using NUnit.Framework;

namespace StdHorizontalMovementTests
{
    [TestFixture]
    public class DualMovableQueueTests
    {
        protected const int VISIABLE_MAX = 3;

        [TestFixture]
        public class Move2RightTests
        {
            protected DualMovableQueue<int> _queue;

            [TestFixtureSetUp]
            public void TestFixtureSetUp()
            {
                _queue = new DualMovableQueue<int>(VISIABLE_MAX);
            }

            [TearDown]
            public void TearDown()
            {
                _queue.Clear();
            }

            [Test]
            public void Given_empty_queue_When_move2right_nothing_changed()
            {
                _queue.Move2Right();
                var expected = new int[] { };
                Assert.AreEqual(expected, _queue.VisibleElements.ToArray());
            }

            [Test]
            public void Given_2_elements_queue_When_move2right_nothing_changed()
            {
                _queue.Append(1);
                _queue.Append(2);

                _queue.Move2Right();

                var expected = new[] { 1, 2 };
                Assert.AreEqual(expected, _queue.VisibleElements.ToArray());
            }

            [Test]
            public void Given_4_elements_queue_and_visiable_window_at_most_right_When_move2right_should_move_to_right_by_1()
            {
                _queue.Append(1);
                _queue.Append(2);
                _queue.Append(3);
                _queue.Append(4);
                _queue.Move2Left();

                _queue.Move2Right();
                var expected = new[] {1, 2, 3};
                Assert.AreEqual(expected, _queue.VisibleElements.ToArray());
            }

            [Test]
            public void Given_5_elements_queue_and_visiable_window_at_middle_When_move2right_should_move_to_right_by_1()
            {
                _queue.Append(1);
                _queue.Append(2);
                _queue.Append(3);
                _queue.Append(4);
                _queue.Append(5);
                _queue.Move2Left();
                _queue.Move2Left();

                _queue.Move2Right();
                var expected = new[] { 2, 3, 4 };
                Assert.AreEqual(expected, _queue.VisibleElements.ToArray());
            }

            [Test]
            public void Given_5_elements_queue_and_visible_window_at_most_right_When_move2right_twice_should_move_to_right_by_2()
            {
                _queue.Append(1);
                _queue.Append(2);
                _queue.Append(3);
                _queue.Append(4);
                _queue.Append(5);
                _queue.Move2Left();
                _queue.Move2Left();

                _queue.Move2Right();
                _queue.Move2Right();
                var expected = new[] { 1, 2, 3 };
                Assert.AreEqual(expected, _queue.VisibleElements.ToArray());
            }
        }

        [TestFixture]
        public class Move2LeftTests
        {
            protected DualMovableQueue<int> _queue;

            [TestFixtureSetUp]
            public void TestFixtureSetUp()
            {
                _queue = new DualMovableQueue<int>(VISIABLE_MAX);
            }

            [TearDown]
            public void TearDown()
            {
                _queue.Clear();
            }

            [Test]
            public void Given_empty_queue_When_move2left_nothing_changed()
            {
                _queue.Move2Left();
                var expected = new int[] {};
                Assert.AreEqual(expected, _queue.VisibleElements.ToArray());
            }

            [Test]
            public void Given_2_elements_queue_When_move2left_nothing_changed()
            {
                _queue.Append(1);
                _queue.Append(2);

                _queue.Move2Left();

                var expected = new[] {1, 2};
                Assert.AreEqual(expected, _queue.VisibleElements.ToArray());
            }

            [Test]
            public void Given_4_elements_queue_When_move2left_visiable_window_should_move_to_left_by_1()
            {
                _queue.Append(1);
                _queue.Append(2);
                _queue.Append(3);
                _queue.Append(4);

                _queue.Move2Left();

                var expected = new[] { 2, 3, 4 };
                Assert.AreEqual(expected, _queue.VisibleElements.ToArray());
            }

            [Test]
            public void Given_4_elements_queue_When_move2left_twice_visiable_window_should_move_to_left_by_1()
            {
                _queue.Append(1);
                _queue.Append(2);
                _queue.Append(3);
                _queue.Append(4);

                _queue.Move2Left();
                _queue.Move2Left();

                var expected = new[] { 2, 3, 4 };
                Assert.AreEqual(expected, _queue.VisibleElements.ToArray());
            }

            [Test]
            public void Given_5_elements_queue_When_move2left_twice_visiable_window_should_move_to_left_by_2()
            {
                _queue.Append(1);
                _queue.Append(2);
                _queue.Append(3);
                _queue.Append(4);
                _queue.Append(5);

                _queue.Move2Left();
                _queue.Move2Left();

                var expected = new[] { 3, 4, 5 };
                Assert.AreEqual(expected, _queue.VisibleElements.ToArray());
            }
        }

        [TestFixture]
        public class AppendTests
        {
            protected DualMovableQueue<int> _queue;

            [TestFixtureSetUp]
            public void TestFixtureSetUp()
            {
                _queue = new DualMovableQueue<int>(VISIABLE_MAX);
            }

            [Test]
            public void Given_empty_queue_When_append_1_element_visiable_window_size_equal_to_1()
            {
                _queue.Append(1);

                var expected = new[] {1};
                Assert.AreEqual(expected, _queue.VisibleElements.ToArray());
            }

            [Test]
            public void Given_full_visiable_window_When_append_1_element_visiable_window_no_change()
            {
                _queue.Append(1);
                _queue.Append(2);
                _queue.Append(3);

                _queue.Append(4);

                var expected = new[] {1, 2, 3};
                Assert.AreEqual(expected, _queue.VisibleElements.ToArray());
            }
        }

        [TestFixture]
        public class ClearTests
        {
            protected DualMovableQueue<int> _queue;

            [TestFixtureSetUp]
            public void TestFixtureSetUp()
            {
                _queue = new DualMovableQueue<int>(VISIABLE_MAX);
            }

            [Test]
            public void Given_3_elements_queue_When_clear_should_be_empty()
            {
                _queue.Append(1);
                _queue.Append(2);
                _queue.Append(3);

                _queue.Clear();

                Assert.AreEqual(0, _queue.Count);
                Assert.AreEqual(0, _queue.VisibleCount);
            }
        }

        [TestFixture]
        public class Move2FirstTests
        {
            protected DualMovableQueue<int> _queue;

            [TestFixtureSetUp]
            public void TestFixtureSetUp()
            {
                _queue = new DualMovableQueue<int>(VISIABLE_MAX);
            }

            [TearDown]
            public void TearDown()
            {
                _queue.Clear();
            }

            [Test]
            public void Given_5_elements_queue_and_visible_window_at_most_right_When_move2first_then_visible_window_should_be_at_the_begin()
            {
                _queue.Append(1);
                _queue.Append(2);
                _queue.Append(3);
                _queue.Append(4);
                _queue.Append(5);
                _queue.Move2Left();
                _queue.Move2Left();

                _queue.Move2First();

                var expected = new[] {1, 2, 3};
                Assert.AreEqual(expected, _queue.VisibleElements.ToArray());
            }

            [Test]
            public void Given_empty_queue_When_move2firt_nothing_changed()
            {
                _queue.Move2First();

                var expected = new int[] {};
                Assert.AreEqual(expected, _queue.VisibleElements);
            }

            [Test]
            public void Given_6_elements_queue_and_visible_window_at_the_end_When_move2first_and_move2left_then_visible_window_should_1_step_to_the_begin()
            {
                _queue.Append(1);
                _queue.Append(2);
                _queue.Append(3);
                _queue.Append(4);
                _queue.Append(5);
                _queue.Append(6);

                _queue.Move2Last();
                _queue.Move2First();
                _queue.Move2Left();

                var expectedPrint = string.Join(",", new[] { 2, 3, 4 });
                Assert.AreEqual(expectedPrint, string.Join(",", _queue.VisibleElements.ToArray()));
            }
        }

        [TestFixture]
        public class Move2LastTests
        {
            protected DualMovableQueue<int> _queue;

            [TestFixtureSetUp]
            public void TestFixtureSetUp()
            {
                _queue = new DualMovableQueue<int>(VISIABLE_MAX);
            }

            [TearDown]
            public void TearDown()
            {
                _queue.Clear();
            }

            [Test]
            public void Given_empty_queue_When_move2last_nothing_changed()
            {
                _queue.Move2Last();

                var expected = new int[] { };
                Assert.AreEqual(expected, _queue.VisibleElements);
            }

            [Test]
            public void Given_5_elements_queue_When_move2last_then_visible_window_should_be_at_the_end()
            {
                _queue.Append(1);
                _queue.Append(2);
                _queue.Append(3);
                _queue.Append(4);
                _queue.Append(5);
                
                _queue.Move2Last();

                var expected = new[] { 3, 4, 5 };
                Assert.AreEqual(expected, _queue.VisibleElements.ToArray());
            }

            [Test]
            public void Given_6_elements_queue_When_move2last_and_move2right_then_visible_window_should_1_step_to_the_end()
            {
                _queue.Append(1);
                _queue.Append(2);
                _queue.Append(3);
                _queue.Append(4);
                _queue.Append(5);
                _queue.Append(6);

                _queue.Move2Last();
                _queue.Move2Right();

                var expectedPrint = string.Join(",", new[] {3, 4, 5});
                Assert.AreEqual(expectedPrint, string.Join(",", _queue.VisibleElements.ToArray()));
            }
        }
    }


}
