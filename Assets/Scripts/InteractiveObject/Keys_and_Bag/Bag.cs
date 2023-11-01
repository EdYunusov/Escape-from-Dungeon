using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Maze2Dgame
{
    public class Bag : MonoBehaviour
    {
        private int m_CountKey;
        public UnityEvent m_ChangeCoundBag;

        public void AddKey(int count)
        {
            m_CountKey += count;
            m_ChangeCoundBag.Invoke();
        }

        public bool DrawKey(int count)
        {
            if (m_CountKey - count < 0) return false;

            m_CountKey -= count;
            m_ChangeCoundBag.Invoke();

            return true;
        }

        public int GetCountKey()
        {
            return m_CountKey;
        }
    }
}

