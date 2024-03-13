
using Scripts.Game.Tile.Base;
using Scripts.Manager;
using TMPro;
using UnityEngine;

namespace Scripts.Game.Tile
{
    public class TileNumberText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textMesh = null;
        [SerializeField] private Tile _gameTile;

        [SerializeField] private TileLevelBehaviour _levelBehaviour;

        private void Awake()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            _gameTile._OnTileDestroyed += OnTileDestroyed;

            EventManager.OnLevelChanged += OnLevelChanged;
        }

        private void UnSubscribe()
        {
            EventManager.OnLevelChanged -= OnLevelChanged;
            _gameTile._OnTileDestroyed -= OnTileDestroyed;
        }

        private void OnLevelChanged()
        {
            _textMesh.text = (Mathf.Pow(2, _levelBehaviour.CurrentLevel + 1)).ToString();
        }

        private void OnTileDestroyed(GameTile tile)
        {
            UnSubscribe();
        }
    }
}