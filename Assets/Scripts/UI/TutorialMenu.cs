using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze2Dgame
{
    public class TutorialMenu : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void OnTutorialButton()
        {
            gameObject.SetActive(true);
        }

        public void OnBackToMenuButton()
        {
            gameObject.SetActive(false);
        }
    }

}
