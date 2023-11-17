using Maze2Dgame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Melee_Type,
    Range_Type
}


public class Follow_AI : MonoBehaviour
{
    public EnemyType enemyType;

    [Header("Enemy Settings")]

    [SerializeField] private float m_Speed;
    [SerializeField] private Transform m_Target;
    [SerializeField] private float m_MinDist;
    [SerializeField] private float m_ShootingRange;
    [SerializeField] private float m_MeleeTriggerRange;
    [SerializeField] private Animator animator;

    [Header("Projectile and shooting system settings")]
    [SerializeField] private Projectile m_Projectile;
    [SerializeField] private GameObject m_ParentProjectile;
    [SerializeField] private float m_FireRate;
    [SerializeField] private float m_NextShotTime;

    [SerializeField] private GameObject battleScene;

    public GameObject BattleScene => battleScene;

    private Vector2 direction;
    private bool isMoving;

    private void Start()
    {
        m_Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (enemyType == EnemyType.Range_Type)
        {
            float distanceFromPlayer = Vector2.Distance(transform.position, m_Target.position);
            if (distanceFromPlayer < m_MinDist && distanceFromPlayer > m_ShootingRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, m_Target.position, m_Speed * Time.deltaTime);
            }
            else if (distanceFromPlayer <= m_ShootingRange && m_NextShotTime < Time.time)
            {
                //сегмент, отвечающий за анимацию???
                animator.SetBool("isMoving", true);
                direction.x = distanceFromPlayer; //Ќеправильное значение? Ќужно верно передать значение на direction, но € не понимаю какое именно тут должно быть значение.
                if (direction.x != 0)
                {
                    animator.SetFloat("Horizontal", direction.x);
                }

                direction.y = distanceFromPlayer; //Ќеправильное значение? Ќужно верно передать значение на direction, но € не понимаю какое именно тут должно быть значение.
                if (direction.y != 0)
                {
                    animator.SetFloat("Vertical", direction.y);
                }

                Projectile currentProjectile = Instantiate(m_Projectile, m_ParentProjectile.transform.position, Quaternion.identity);
                m_NextShotTime = Time.time + m_FireRate;
                currentProjectile.SetFollow_AI(this);
            }
        }

        if (enemyType == EnemyType.Melee_Type)
        {
            float distanceFromPlayer = Vector2.Distance(transform.position, m_Target.position);
            if (distanceFromPlayer < m_MinDist && distanceFromPlayer > m_MeleeTriggerRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, m_Target.position, m_Speed * Time.deltaTime);
            }
            else if (distanceFromPlayer <= m_MeleeTriggerRange)
            {
                //сегмент, отвечающий за анимацию???
                animator.SetBool("isMoving", true);
                direction.x = Input.GetAxisRaw("Horizontal");
                if (direction.x != 0)
                {
                    animator.SetFloat("Horizontal", direction.x);
                }

                direction.y = Input.GetAxisRaw("Vertical");
                if (direction.y != 0)
                {
                    animator.SetFloat("Vertical", direction.y);
                }
                EnableBattleScene();
            }
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

        BattelSystem bs = battleScene.GetComponentInChildren<BattelSystem>();
        bs.playerPrefab = m_Target.gameObject;
        bs.enemyPrefab = gameObject;
    }

}
