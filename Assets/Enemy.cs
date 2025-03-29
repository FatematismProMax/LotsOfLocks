using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 1;
    bool movingRight;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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


    }
}
