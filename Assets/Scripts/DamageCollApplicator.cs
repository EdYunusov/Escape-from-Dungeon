using UnityEngine;

namespace Maze2Dgame
{
    public class DamageCollApplicator : MonoBehaviour
    {
        public static string IgnoreTag = "WorldBoundary";

        [SerializeField] private float m_VelosityDamage;

        [SerializeField] private float m_DamageConstant;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var destructable = transform.root.GetComponent<Destructible>();

            if (collision.transform.tag == IgnoreTag) return;

            if (destructable != null)
            {
                destructable.ApplayDamage((int)m_DamageConstant + (int)(m_VelosityDamage * collision.relativeVelocity.magnitude));
            }
        }
    }
}

