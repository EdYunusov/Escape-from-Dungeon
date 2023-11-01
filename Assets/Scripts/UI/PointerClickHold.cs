using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Maze2Dgame
{
    public class PointerClickHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool m_Hold;
        public bool isHold => m_Hold;
        public void OnPointerDown(PointerEventData eventData)
        {
            m_Hold = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            m_Hold = false;
        }



    }
}

