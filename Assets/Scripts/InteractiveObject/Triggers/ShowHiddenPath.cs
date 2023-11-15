using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHiddenPath : MonoBehaviour
{
    [SerializeField] private TriggerHidenPath button;
    [SerializeField] private GameObject hiddenPath;
    private void Start()
    {
        hiddenPath.SetActive(true);
    }

    public void KeyPressdCheck()
    {
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            Debug.Log("Key pressed");
            if ( button.Reached == false)
            {
                hiddenPath.SetActive(false);
            }
        }
    }
}
