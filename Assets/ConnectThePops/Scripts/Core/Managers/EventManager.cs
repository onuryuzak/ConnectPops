using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Manager
{
    public static class EventManager
    {
        #region delegates

        public delegate void LevelChanged();

        public delegate void ClickedTile(int sumScore);

        public delegate void UnClickedTile();

        #endregion

        #region events

        public static event LevelChanged OnLevelChanged;
        public static event ClickedTile OnClickedTile;
        public static event UnClickedTile OnUnClickedTile;

        #endregion

        #region function

        public static void DelegateLevelChanged()
        {
            OnLevelChanged?.Invoke();
        }

        public static void DelegateClickedTile(int sumScore)
        {
            OnClickedTile?.Invoke(sumScore);
        }

        public static void DelegateUnClickedTile()
        {
            OnUnClickedTile?.Invoke();
        }

        #endregion
    }
}