using System.Collections.Generic;
using Scripts.Game.Tile.Base;
using Scripts.Manager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Scripts.Game.Tile
{
    public class TileLevelBehaviour : LevelUpBehaviour
    {
        [SerializeField] private List<Color> levelColors = new List<Color>();
        int currentLevel = 0;

        public override int CurrentLevel
        {
            get => currentLevel;

            set
            {
                currentLevel = value;

                EventManager.DelegateLevelChanged();
            }
        }

        public Color Color
        {
            get
            {
                int index = Mathf.Min(currentLevel, levelColors.Count - 1);

                return levelColors[index];
            }
        }

        public void SetLevel(int level)
        {
            CurrentLevel = level;
        }


        public override void LevelUp()
        {
            CurrentLevel++;
        }
    }
}