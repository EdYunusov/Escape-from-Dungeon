using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Maze2Dgame
{
    public class Projectile : MonoBehaviour
    {

        [SerializeField] private float speed;
        [SerializeField] private float m_LifeTime;
 
        private Vector3 m_TargetPos;
        private float m_Timer;

        private Follow_AI follow_AI;

        private void Start()
        {
            m_TargetPos = FindObjectOfType<PlayerController>().transform.position;
        }

        private void Update()
        {
            if (m_Timer > m_LifeTime) Destroy(gameObject);
            transform.position = Vector2.MoveTowards(transform.position, m_TargetPos, speed * Time.deltaTime);

            if(transform.position == m_TargetPos)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
                if (hit)
                {
                    Destructible dist = hit.collider.transform.root.GetComponent<Destructible>();
                    if (dist != null)
                    { 
                        WaitForSeconde();
                        follow_AI.EnableBattleScene();
                    }
                    OnProjectileLifeTimeEnd(hit.collider, hit.point);
                }
            }
        }

        private void OnProjectileLifeTimeEnd(Collider2D col, Vector2 pos)
        {
            Destroy(gameObject);
        }

        IEnumerator WaitForSeconde()
        {
            yield return new WaitForSeconds(5f);
        }

        public void SetFollow_AI(Follow_AI ai_object) 
        {
            follow_AI = ai_object;
        }

    }
}

