using UnityEngine;

namespace Scripts.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        void Update()
        {
            if (IsReturnButtonDown())
            {
                QuitApplication();
            }
        }

        bool IsReturnButtonDown()
        {
            return Input.GetKeyDown(KeyCode.Escape);
        }

        void QuitApplication()
        {
            Application.Quit();
        }
    }
}