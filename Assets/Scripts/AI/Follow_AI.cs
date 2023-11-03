using Maze2Dgame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Follow_AI : MonoBehaviour
{
    [SerializeField] private float m_Speed;
    [SerializeField] private Transform m_Target;
    [SerializeField] private float m_MinDist;
    [SerializeField] private float m_ShootingRange;
    [SerializeField] private GameObject m_Projectile;
    [SerializeField] private GameObject m_ParentProjectile;
    [SerializeField] private float m_FireRate;
    [SerializeField] private float m_NextShotTime;

    [SerializeField] private GameObject battleScene;

    public GameObject BattleScene => battleScene;


    private void Start()
    {
        m_Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distanceFromPlayer = Vector2.Distance(transform.position, m_Target.position);
        if (distanceFromPlayer < m_MinDist && distanceFromPlayer > m_ShootingRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, m_Target.position, m_Speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= m_ShootingRange && m_NextShotTime < Time.time)
        {
            Instantiate(m_Projectile, m_ParentProjectile.transform.position, Quaternion.identity);
            m_NextShotTime = Time.time + m_FireRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, m_MinDist);
        Gizmos.DrawWireSphere(transform.position, m_ShootingRange);
    }

    public void EnableBattleScene()
    {
        battleScene.SetActive(true);
    }

}
