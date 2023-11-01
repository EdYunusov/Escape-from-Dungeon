using UnityEngine;

namespace Maze2Dgame
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Camera m_Camera;
        [SerializeField] private Transform m_Target;
        [SerializeField] private float m_InterpolationLinear;
        [SerializeField] private float m_InterpolationAnguler;
        [SerializeField] private float m_CameraOffset;


        private void FixedUpdate()
        {

            if (m_Target == null || m_Camera == null) return;

            Vector2 camPosition = m_Camera.transform.position;
            Vector2 targetPosition = m_Target.position + m_Target.transform.up;
            Vector2 newCamPosition = Vector2.Lerp(camPosition, targetPosition, m_InterpolationLinear * Time.deltaTime);

            m_Camera.transform.position = new Vector3(newCamPosition.x, newCamPosition.y, m_CameraOffset);

            if (m_InterpolationAnguler > 0)
            {
                m_Camera.transform.rotation = Quaternion.Slerp(m_Camera.transform.rotation, m_Target.rotation, m_InterpolationAnguler * Time.deltaTime);
            }
        }

        public void SetTarget(Transform newTarget)
        {
            m_Target = newTarget;
        }
    }

}
