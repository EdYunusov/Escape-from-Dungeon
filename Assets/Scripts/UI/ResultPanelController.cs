using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Maze2Dgame
{
    public class ResultPanelController : SingletonBase<ResultPanelController>
    {
        [SerializeField] private Text m_Kills;
        [SerializeField] private Text m_Score;
        [SerializeField] private Text m_Time;
        [SerializeField] private Text m_Result;
        [SerializeField] private Text m_ButtonNextText;

        private bool m_Success;


        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void ShowResult(bool success)
        {
            
            gameObject.SetActive(true);

            m_Success = success;

            m_Result.text = success ? "Win" : "Lose";

            m_ButtonNextText.text = success ? "Next" : "Restart";

            Time.timeScale = 0;
        }

        public void OnButtonNextAction()
        {
            gameObject.SetActive(false);

            Time.timeScale = 1;

            if(m_Success)
            {
                LevelSequenceController.Instance.AvanceLevel();
            }
            else
            {
                LevelSequenceController.Instance.RestartLevel();
            }
        }
    }
}

