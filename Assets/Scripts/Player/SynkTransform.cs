using UnityEngine;

namespace Maze2Dgame
{
    public class SynkTransform : MonoBehaviour
    {
        [SerializeField] private Transform m_Target;
        void Update()
        {
            transform.position = new Vector3(m_Target.position.x, m_Target.position.y, transform.position.z);
        }
    }
}

