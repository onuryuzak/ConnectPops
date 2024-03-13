using System.Collections;

namespace Scripts.State
{
    public interface IState
    {
        IEnumerator Execute();
    }
}