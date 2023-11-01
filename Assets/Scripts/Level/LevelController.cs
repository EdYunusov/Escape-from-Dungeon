using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Maze2Dgame
{
    public interface ILevelCondition
    {
        bool IsComplited { get; }

    }

    public class LevelController : SingletonBase<LevelController>
    {
        

        [SerializeField] private int m_ReferenceTime;
        public int ReferenceTime => m_ReferenceTime;

        [SerializeField] private UnityEvent m_EventLevelConplited;

        private ILevelCondition[] m_Conditions;

        private bool m_IsLevelComplited;
        private float m_LevelTime;
        public float LevelTime => m_LevelTime;

        void Start()
        {
            m_Conditions = GetComponentsInChildren<ILevelCondition>();
        }


        void Update()
        {
            if(!m_IsLevelComplited)
            {
                m_LevelTime += Time.deltaTime;

                CheckLevelConditions();
            }
        }

        private void CheckLevelConditions()
        {
            if (m_Conditions == null || m_Conditions.Length == 0) return;

            int numCompleted = 0;

            foreach(var v in m_Conditions)
            {
                if (v.IsComplited) numCompleted++;
            }

            if(numCompleted == m_Conditions.Length)
            {
                m_IsLevelComplited = true;
                m_EventLevelConplited?.Invoke();

                LevelSequenceController.Instance?.FinishCurrentLevel(true);
            }
        }
    }

}
