using Scripts.Game.Selection;
using Scripts.Game.Tile.Base;

namespace Scripts.Game.Validator
{
    public class LevelValidator : IConnectionValidator
    {
        ISelection selection;

        public LevelValidator(ISelection selection)
        {
            this.selection = selection;
        }

        public bool IsValid(GameTile first, GameTile second)
        {
            if (first is ICanLevelUp firstLevel && second is ICanLevelUp secondLevel)
            {
                return AreSequel(firstLevel,secondLevel);
            }

            return false;
        }

        private bool AreSequel(ICanLevelUp firstLevel, ICanLevelUp secondLevel)
        {
            return (firstLevel.CurrentLevel == secondLevel.CurrentLevel);
        }
    }
}