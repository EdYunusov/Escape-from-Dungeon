using UnityEngine;
using UnityEngine.Events;

public class TriggerHidenPath : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private UnityEvent m_Enter;
    [SerializeField] private GameObject keyboard_Messag;
    [SerializeField] private ShowHiddenPath path;


    private bool isActive = false;
    private bool m_Reached;


    public bool Reached => m_Reached;


    private void Start()
    {
        player = GetComponent<PlayerController>();
        keyboard_Messag.SetActive(false);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActive == true) return;

        player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            keyboard_Messag.SetActive(true);
            path.KeyPressdCheck();
        }
        m_Reached = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        keyboard_Messag.SetActive(false);
        m_Reached = true;
    }
    
}
