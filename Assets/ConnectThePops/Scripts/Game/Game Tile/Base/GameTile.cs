using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Scripts.Game.Tile.Base
{
    [RequireComponent(typeof(TileMoveToBehaviour))]
    public class GameTile : MonoBehaviour
    {
        [SerializeField] protected Collider2D _inputCollider = null;
        [SerializeField] private TileRenderer _tileRenderer;

        public TileRenderer TileRenderer
        {
            get => _tileRenderer;
            set => _tileRenderer = value;
        }

        public UnityAction<GameTile> _OnTileDestroyed { get; set; }

        public virtual bool IsDestroyed { get; private set; }

        public virtual void EnableCollider()
        {
            _inputCollider.enabled = true;
        }

        public virtual void DisableCollider()
        {
            _inputCollider.enabled = false;
        }

        public virtual void Pop()
        {
            IsDestroyed = true;

            DisableCollider();

            _OnTileDestroyed?.Invoke(this);

            Destroy(gameObject, 1.0f);
        }
    }
}