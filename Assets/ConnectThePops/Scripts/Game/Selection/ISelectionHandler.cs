using Scripts.Game.Tile.Base;

namespace Scripts.Game.Selection
{
    public interface ISelectionHandler
    {
        void HandleSelection(GameTile gameTile);
        void ReleaseSelection();
    }
}