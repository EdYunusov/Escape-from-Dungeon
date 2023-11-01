using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze2Dgame
{
    public class LevelConditionPosition : MonoBehaviour
    {
        private bool m_Reached;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Character character = collision.transform.root.GetComponent<Character>();

            if (character != null)
            {
                m_Reached = true;
                Debug.Log("Reached!");
                LevelSequenceController.Instance.FinishCurrentLevel(m_Reached);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Character character = collision.transform.root.GetComponent<Character>();

            if (character != null)
            {
                m_Reached = false;
            }
        }
    }

}
