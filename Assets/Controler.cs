using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controler : MonoBehaviour {

    public float speed = 7f;
    public float jumpingSpeed = 7f;
    private float movement = 0f;

    public bool facingRight = true;
	
	
	void FixedUpdate () {
        movement = Input.GetAxis("Horizontal");
        if (movement < 0)
            GetComponent<Rigidbody2D>().velocity = new Vector3(movement * speed,GetComponent<Rigidbody2D>().velocity.y);
        if (movement > 0)
            GetComponent<Rigidbody2D>().velocity = new Vector3(movement * speed, GetComponent<Rigidbody2D>().velocity.y);

        if (movement < 0 && facingRight)
            Flip();
        if (movement > 0 && !facingRight)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);

    }
}
