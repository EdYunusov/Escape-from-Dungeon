using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Maze2Dgame
{
    public class KeysCount : MonoBehaviour
    {
        [SerializeField] private Bag bag;
        [SerializeField] private Text text;

        private void Start()
        {
            bag.m_ChangeCoundBag.AddListener(OnChangeText);
        }

        private void OnDestroy()
        {
            bag.m_ChangeCoundBag.RemoveListener(OnChangeText);
        }

        private void OnChangeText()
        {
            text.text = bag.GetCountKey().ToString();
        }
    }
}

