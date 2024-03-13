using System.Collections.Generic;
using System.Linq;
using Scripts.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Scripts.Game.UI
{
    public class SumUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _sumText;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private List<Color> levelColors = new List<Color>();
        private int score;

        private void OnEnable()
        {
            EventManager.OnClickedTile += OnClickedTile;
            EventManager.OnUnClickedTile += OnUnClickedTile;
        }

        private void OnDisable()
        {
            EventManager.OnClickedTile -= OnClickedTile;
            EventManager.OnUnClickedTile -= OnUnClickedTile;
        }

        private void OnClickedTile(int currentScore)
        {
            score = currentScore;
            _sumText.transform.parent.gameObject.SetActive(true);
            _sumText.text = currentScore.ToString();
            _backgroundImage.color = GetBackgroundColor();
        }

        private void OnUnClickedTile()
        {
            _sumText.transform.parent.gameObject.SetActive(false);
        }

        private Color GetBackgroundColor()
        {
            var value = (int)Mathf.Log(score, 2);
            var index = Mathf.Min(value, levelColors.Count - 1);
            return levelColors[index - 1];
        }
    }
}