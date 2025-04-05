using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 1;
    bool movingRight;
    public Transform player;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (rb.velocity.x == 0) {
        //    movingRight = !movingRight;
        //}

        //Vector2 movement = rb.velocity;

        //if (movingRight) {
        //    movement.x = moveSpeed;
        //}
        //else {
        //    movement.x = -moveSpeed;
        //}

        //rb.velocity = movement;

        GetComponent<NavMeshAgent>().SetDestination(player.position);

        Vector3 dir = GetComponent<NavMeshAgent>().velocity.normalized;      
        


        if (dir.x < 0.5f)
        {
            animator.SetBool("WalkLeft", true);
            animator.SetBool("WalkDown", false);
            spriteRenderer.flipX = false;
        }
        else if (dir.x > 0.5f)
        {
            animator.SetBool("WalkLeft", true);
            animator.SetBool("WalkDown", false);
            spriteRenderer.flipX = true;
        }
        else if (dir.y < 0.5f)
        {
            animator.SetBool("WalkDown", true);
            animator.SetBool("WalkLeft", false);
        }

    }
}
