using System;
using DG.Tweening;
using Scripts.Game.Tile.Base;
using Scripts.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Game.Tile
{
    public class TileRenderer : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer = null;

        public SpriteRenderer SpriteRenderer
        {
            get => _spriteRenderer;
            set => _spriteRenderer = value;
        }

        [SerializeField] private Tile _gameTile;
        [SerializeField] private TileLevelBehaviour _levelBehaviour;

        private void Awake()
        {
            Subscribe();
            SetRendererInitialScale();
            SetRendererScaleWithAnimation(Vector3.one, 0.3f);
        }

        private void SetRendererInitialScale()
        {
            _spriteRenderer.gameObject.transform.localScale = Vector3.zero;
        }

        private void SetRendererScaleWithAnimation(Vector3 scaleVector, float duration)
        {
            _spriteRenderer.gameObject.transform.DOScale(scaleVector, duration);
        }

        public void SetRendererScale(Vector3 scaleVector)
        {
            _spriteRenderer.gameObject.transform.localScale = scaleVector;
        }

        private void Subscribe()
        {
            _gameTile._OnTileDestroyed += OnTileDestroyed;
            EventManager.OnLevelChanged += OnLevelChanged;
        }

        private void UnSubscribe()
        {
            _gameTile._OnTileDestroyed -= OnTileDestroyed;
            EventManager.OnLevelChanged -= OnLevelChanged;
        }

        private void OnLevelChanged()
        {
            _spriteRenderer.color = _levelBehaviour.Color;
        }

        private void OnTileDestroyed(GameTile tile)
        {
            UnSubscribe();
            _spriteRenderer.gameObject.SetActive(false);
        }
    }
}