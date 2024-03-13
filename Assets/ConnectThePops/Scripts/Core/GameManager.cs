using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameModeBase _gameModeBase = null;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
        }

        IEnumerator Start()
        {
            yield return _gameModeBase.StartGame();
            yield return _gameModeBase.RunGame();
        }
    }
}