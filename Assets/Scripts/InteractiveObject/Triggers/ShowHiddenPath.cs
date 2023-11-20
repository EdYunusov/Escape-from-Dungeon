using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ShowHiddenPath : MonoBehaviour
{
    [SerializeField] private TriggerHidenPath button;
    [SerializeField] private GameObject hiddenPath;
    [SerializeField] private AudioSource audio;

    private void Start()
    {
        hiddenPath.SetActive(true);
    }

    private void Update()
    {
        KeyPressdCheck();
    }

    public void KeyPressdCheck()
    {
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            Debug.Log("Key pressed");
            if (button.Reached == false)
            {
                hiddenPath.SetActive(false);
                audio.Play();
            }
        }
    }
}
