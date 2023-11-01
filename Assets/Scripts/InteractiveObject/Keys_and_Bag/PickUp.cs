using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze2Dgame
{
    public class PickUp : MonoBehaviour
    {
        protected virtual void On2DTriggerEnter(Collider2D collider)
        {
            Character character = collider.GetComponent<Character>();
            
            if (character != null)
            {
                Destroy(gameObject);
            }
        }
    }
}

