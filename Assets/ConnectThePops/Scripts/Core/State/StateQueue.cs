using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Scripts.State
{
    public class StateQueue : IState
    {
        Queue<IState> queue;

        public StateQueue()
        {
            queue = new Queue<IState>();
        }

        public void Clear()
        {
            queue.Clear();
        }

        public void Add(IState state)
        {
            queue.Enqueue(state);
        }

        public IEnumerator Execute()
        {
            return queue.Select(operation => operation.Execute()).GetEnumerator();
        }
    }
}