using UnityEngine;

namespace Maze2Dgame
{
    public class MovementController : MonoBehaviour
    {
        public enum ControlMode
        {
            Keyboard,
            Mobile
        }

        [SerializeField] private Character m_TargetCharacter;
        public void SetTargetCharacter(Character chars) => m_TargetCharacter = chars;

        [SerializeField] private VirtualJoystick m_MobileJoystick;
        [SerializeField] private ControlMode m_ControlMode;
        [SerializeField] private PointerClickHold m_MobildeFirePrimary;
        [SerializeField] private PointerClickHold m_MobildeFireSecondary;
        [SerializeField] private GameObject m_pauseMenu;

        private void Start()
        {
            if (m_ControlMode == ControlMode.Keyboard)
            {
                m_MobileJoystick.gameObject.SetActive(false);
                m_MobildeFirePrimary.gameObject.SetActive(false);
                m_MobildeFireSecondary.gameObject.SetActive(false);
            }
            else
            {
                m_MobileJoystick.gameObject.SetActive(true);
                m_MobildeFirePrimary.gameObject.SetActive(true);
                m_MobildeFireSecondary.gameObject.SetActive(true);
            }
        }

        private void Update()
        {
            if (m_TargetCharacter == null) return;

            if (m_ControlMode == ControlMode.Keyboard)
                ControlKeyboard();
        }


        private void ControlKeyboard()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                m_pauseMenu.SetActive(true);
            }
        }
    }
}

