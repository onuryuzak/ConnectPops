using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Grid
{
    public class Row : MonoBehaviour, IRow
    {
        [SerializeField] private float _cellSize = 1.0f;

        [SerializeField] private int _width = 0;

        public int Width
        {
            get => _width;
            set { _width = value; }
        }

        private void OnDrawGizmos()
        {
            for (int x = 0; x < _width; x++)
            {
                var cellPos = GetPosition(x);

                Gizmos.DrawWireCube(cellPos, Vector3.one * _cellSize);
            }
        }

        private Vector3 GetPosition(int x)
        {
            var centerOfRow = transform.position;

            float widthOfRow = Width * _cellSize;

            var mostLeftCellPosition = centerOfRow - Vector3.right * (widthOfRow - _cellSize) / 2;

            return mostLeftCellPosition + Vector3.right * x * _cellSize;
        }
    }
}