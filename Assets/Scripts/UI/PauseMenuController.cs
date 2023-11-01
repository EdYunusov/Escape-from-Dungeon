using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Maze2Dgame
{
    public class PauseMenuController : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive(false);
            Debug.Log("Menu off");
        }

        public void OnButtonShowPause()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("CLICK! Menu ON!");
        }

        public void OnContinueButton()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        public void OnMainMenuButton()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);

            SceneManager.LoadScene(0);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
