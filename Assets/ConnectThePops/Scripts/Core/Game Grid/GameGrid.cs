using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Grid
{
    public class GameGrid : MonoBehaviour, IGameGrid
    {
        [SerializeField] private int _width = 0;

        [SerializeField] private int _height = 0;

        [SerializeField] private float _cellSize = 0.0f;
        [SerializeField] private float _tileYOffset = 0.0f;
        public int Width => _width;
        public int Height => _height;
        public float CellSize => _cellSize;

        public Vector3 BottomLeftCorner => new()
        {
            x = transform.position.x - (_width * _cellSize) / 2,
            y = transform.position.y - (_height * _cellSize) / 2,
            z = transform.position.z
        };

        public Vector3 GetPosition(int x, int y)
        {
            return BottomLeftCorner + Vector3.one * CellSize / 2 + new Vector3(x, y + _tileYOffset, 0) * CellSize;
        }

        private void OnDrawGizmos()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var cellPos = GetPosition(x, y);

                    Gizmos.DrawWireCube(cellPos, Vector3.one * CellSize);
                }
            }
        }
    }
}