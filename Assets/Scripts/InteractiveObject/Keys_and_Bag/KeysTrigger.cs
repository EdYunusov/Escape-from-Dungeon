using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Maze2Dgame
{
    public class KeysTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject m_MessagBox;
        [SerializeField] private int m_CountKeyActive;
        [SerializeField] private UnityEvent m_Enter;
        [SerializeField] private int m_NextLevelNumber;

        private GameManager m_gameManager;
        private bool isActive = false;
        private bool m_Reached;

        private void Start()
        {
            m_gameManager = FindObjectOfType<GameManager>();
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (isActive == true) return;


            Bag bag = collision.GetComponent<Bag>();


            if (bag != null)
            {
                if (bag.DrawKey(m_CountKeyActive) == true)
                {
                    m_Enter.Invoke();
                    isActive = true;
                    m_Reached = true;
                    Debug.Log("Reached!");
                    m_gameManager.LoadNextLevel(m_NextLevelNumber);
                    
                }
                else
                {
                    m_MessagBox.SetActive(true);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            m_MessagBox.SetActive(false);
            m_Reached = false;
        }
    }
}
