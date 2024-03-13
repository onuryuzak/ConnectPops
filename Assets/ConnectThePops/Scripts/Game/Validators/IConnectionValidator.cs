using Scripts.Game.Tile.Base;

namespace Scripts.Game.Validator
{
    public interface IConnectionValidator
    {
        bool IsValid(GameTile first, GameTile second);
    }
}