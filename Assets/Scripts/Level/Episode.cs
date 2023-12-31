using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze2Dgame
{
    [CreateAssetMenu]
    public class Episode : ScriptableObject
    {
        [SerializeField] private string m_EpisodeName;

        public string EpisodeName => m_EpisodeName;

        [SerializeField] private string[] m_Levels;

        public string[] Levels => m_Levels;
    }
}

