using System.Collections;
using Scripts.Game.Tile.Base;
using UnityEngine;

namespace Scripts.Game.Tile
{
    public class TileMoveToBehaviour : MoveToBehaviour
    {
        [SerializeField] private float velocity = 4.0f;
        public override bool IsMoving { get; protected set; }

        private void Awake()
        {
            IsMoving = false;
        }

        public override void MoveTo(Vector3 target)
        {
            if (velocity > 0)
            {
                StartCoroutine(MoveCoroutine(target, velocity));
            }
            else
            {
                Debug.LogWarning("Cannot move object, because velocity is set to zero", this);
            }
        }

        public override void MoveTo(Vector3 target, float duration)
        {
            StartCoroutine(MoveCoroutineInDuration(target, duration));
        }

        IEnumerator MoveCoroutineInDuration(Vector3 target, float duration)
        {
            IsMoving = true;

            Vector3 origin = transform.position;

            float timeElapsed = 0.0f;

            while (timeElapsed <= duration)
            {
                timeElapsed += Time.deltaTime;

                float t = Mathf.Clamp01(timeElapsed / duration);

                transform.position = Vector3.Lerp(origin, target, t);

                yield return null;
            }

            IsMoving = false;
        }

        IEnumerator MoveCoroutine(Vector3 target, float velocity)
        {
            float duration = Vector3.Distance(transform.position, target) / velocity;

            yield return MoveCoroutineInDuration(target, duration);
        }
    }
}