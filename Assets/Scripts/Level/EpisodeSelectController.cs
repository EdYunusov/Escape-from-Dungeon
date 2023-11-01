using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Maze2Dgame
{
    public class EpisodeSelectController : MonoBehaviour
    {
        [SerializeField] private Episode m_Episode;
        [SerializeField] private Text m_EpisodeNickname;
        //[SerializeField] private Image m_PreviewLevels;

        private void Start()
        {
            if (m_EpisodeNickname != null) m_EpisodeNickname.text = m_Episode.EpisodeName;

            //if (m_PreviewLevels != null) m_PreviewLevels.sprite = m_Episode.PreviewLevel;
        }

        public void OnStartEpisodeButton()
        {
            LevelSequenceController.Instance.StartEpisode(m_Episode);
        }
    }
}

