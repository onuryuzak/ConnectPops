using UnityEngine;

namespace Scripts.Game.Tile.Base
{
    public abstract class MoveToBehaviour : MonoBehaviour, ICanMoveTo
    {
        public abstract bool IsMoving { get; protected set; }

        public abstract void MoveTo(Vector3 target);
        public abstract void MoveTo(Vector3 target, float duration);
    }
}