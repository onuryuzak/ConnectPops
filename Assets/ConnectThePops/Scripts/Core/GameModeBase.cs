using System.Collections;
using UnityEngine;

namespace Scripts.Core
{
    public abstract class GameModeBase : MonoBehaviour
    {
        public abstract IEnumerator StartGame();

        public abstract IEnumerator RunGame();
    }
}