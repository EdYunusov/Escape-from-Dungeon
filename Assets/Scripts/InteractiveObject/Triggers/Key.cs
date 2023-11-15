using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze2Dgame
{
    public class Key : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Bag bag = collision.GetComponent<Bag>();

            if(bag != null)
            {
                bag.AddKey(1);
                Destroy(gameObject);
            }

        }
    }
}
