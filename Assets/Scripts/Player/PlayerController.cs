using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    
    [Header("Character settings")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private Animator animator;

    [SerializeField] private AudioSource stepSound;

    private Rigidbody2D rgid;
    private Vector2 direction;


    private void Start()
    {
        rgid = GetComponent<Rigidbody2D>();
        stepSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void FixedUpdate()
    {
        UpdateRigidBody();
    }

    private void UpdateRigidBody()
    {
        rgid.MovePosition(rgid.position + direction * movementSpeed * Time.fixedDeltaTime);
    }

    private void PlayerMovement()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Horizontal", direction.x);
        direction.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Vertical", direction.y);

        rgid.velocity = new Vector2(direction.x, direction.y);

        if (rgid.velocity.x != 0 || rgid.velocity.y != 0)
        {
            if (!stepSound.isPlaying)
            {
                stepSound.Play();
            }
        }
        else
        {
            stepSound.Stop();
        }

        animator.SetFloat("Speed", direction.sqrMagnitude);
    }
}
