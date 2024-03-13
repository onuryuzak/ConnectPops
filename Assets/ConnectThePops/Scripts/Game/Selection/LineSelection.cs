using Scripts.Game.Tile.Base;

namespace Scripts.Game.Selection
{
    public class LineSelection : Selection
    {
        SelectionLineRenderer lineRenderer;

        public LineSelection(SelectionLineRenderer lineRenderer)
        {
            this.lineRenderer = lineRenderer;
        }

        public override void Clear()
        {
            base.Clear();
            lineRenderer.Clear();
        }

        public override void Add(GameTile gameTile)
        {
            base.Add(gameTile);
            lineRenderer.UpdateLine(this);
        }

        public override void Remove(GameTile gameTile)
        {
            base.Remove(gameTile);
            lineRenderer.UpdateLine(this);
        }

        public void ClearLine()
        {
            lineRenderer.Clear();
        }
    }
}