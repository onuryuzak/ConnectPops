using Scripts.Manager;

namespace Scripts.Game
{
    public static class Sum
    {
        public static void Close()
        {
            EventManager.DelegateUnClickedTile();
        }

        public static void Show(float sum)
        {
            EventManager.DelegateClickedTile((int)sum);
        }
    }
}