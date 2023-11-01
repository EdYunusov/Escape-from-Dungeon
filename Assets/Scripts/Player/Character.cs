using System;
using UnityEngine;


namespace Maze2Dgame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : Destructible
    {
        [Header("Character settings")]
        [SerializeField] private float m_Mass;
        [SerializeField] private float m_Acceleration;
        [SerializeField] private float m_Speed;
        [SerializeField] private Animator animator;

        [SerializeField] private AudioSource stepSound;

        private Rigidbody2D m_Rigid;
        private Vector2 direction;


        protected override void Start()
        {
            base.Start();

            m_Rigid = GetComponent<Rigidbody2D>();
            m_Rigid.mass = m_Mass;

            m_Rigid.inertia = 1;
        }

        private void Update()
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("Horizontal", direction.x);
            direction.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Vertical", direction.y);

            animator.SetFloat("Speed", direction.sqrMagnitude);

            stepSound.Play();
        }

        private void FixedUpdate()
        {
            UpdateRigidBody();
        }

        private void UpdateRigidBody()
        {
            m_Rigid.MovePosition(m_Rigid.position + direction * m_Speed * Time.fixedDeltaTime);
            
        }
    }
}

