using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    public float moveSpeed = 3.0f;
    public float jumpSpeed = 7.0f;
    Vector3 respawnPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = rb.velocity;

        GetComponent<Animator>().SetBool("WalkLeft", false);
        GetComponent<Animator>().SetBool("WalkDown", false);

        if (Input.GetKey(KeyCode.RightArrow)) {
            movement.x = moveSpeed;
            GetComponent<Animator>().SetBool("WalkLeft", true);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            movement.x = -moveSpeed;
            GetComponent<Animator>().SetBool("WalkLeft", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            movement.z = moveSpeed;
            GetComponent<Animator>().SetBool("WalkLeft", true);            
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movement.z = -moveSpeed;
            GetComponent<Animator>().SetBool("WalkDown", true);
        }
        else {
            movement.x = 0;
            movement.z = 0;           
        }
        
        //if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0) {
        //    movement.y = jumpSpeed;
        //}

        //Debug.Log(movement);

        rb.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Hit object named: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Enemy")) {

            if (rb.velocity.y < 0) {
                Destroy(collision.gameObject);
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
            else {
                transform.position = respawnPos;
            }
        }
    }
}
