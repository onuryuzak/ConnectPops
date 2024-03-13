using Scripts.Game.Selection;

namespace Scripts.Game.Validator
{
    public class SelectionValidator : IValidator
    {
        ISelection selection;

        public SelectionValidator(ISelection selection)
        {
            if (selection == null)
            {
                throw new System.ArgumentException("Parameter cannot be null", "selection");
            }

            this.selection = selection;
        }
        public bool IsValid
        {
            get
            {
                if (selection == null)
                {
                    throw new System.Exception("Selection cannot be null");
                }

                return this.selection.Count >= Rules.MinRequiredTileCount;
            }
        }
    }
}