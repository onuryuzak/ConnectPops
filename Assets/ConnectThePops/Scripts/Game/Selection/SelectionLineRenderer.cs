using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Game.Selection
{
    public class SelectionLineRenderer : MonoBehaviour
    {
        [SerializeField] LineRenderer _lineRenderer = null;

        public void Clear()
        {
            _lineRenderer.positionCount = 0;
        }

        public void UpdateLine(ISelection selection)
        {
            _lineRenderer.positionCount = 0;
            _lineRenderer.startColor = selection.GetColor();
            _lineRenderer.endColor = selection.GetColor();

            for (int i = 0; i < selection.Count; i++)
            {
                if (i > 0)
                {
                    var previous = selection.Get(i - 1);
                    var current = selection.Get(i);

                    AddLineSegment(previous.transform.position, current.transform.position);
                }
            }
        }

        void AddLineSegment(Vector3 start, Vector3 end)
        {
            int steps = 5;
            float stepSize = 1.0f / steps;

            for (int i = 0; i <= steps; i++)
            {
                Vector3 center = Vector3.Lerp(start, end, i * stepSize);
                AddPoint(center);
            }
        }

        void AddPoint(Vector3 position)
        {
            _lineRenderer.positionCount++;
            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, new Vector2(position.x, position.y));
        }

        private void Reset()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.sharedMaterial.color = Color.white;
        }
    }
}