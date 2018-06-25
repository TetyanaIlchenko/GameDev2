using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedOrc : Orc {
  
    
    private float amount_carrot = 0f;
    public GameObject carrot;
    private Animator redOrcAnim = null;

    public float radius = 0;
    public float interval = 0;

	// Use this for initialization
	void Start () {
        redOrcAnim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (mode == Mode.GoToA)
        {
            if (IsArrived(pointA))
            {
                mode = Mode.GoToB;
            }
        }
        else if (mode == Mode.GoToB)
        {
            if (IsArrived(pointB))
            {
                mode = Mode.GoToA;
            }
        }

    }
    void FixedUpdate()
    {
        float value = this.GetDirection();

        if (value < 0)
            GetComponent<Rigidbody2D>().velocity = new Vector3(value * speed, GetComponent<Rigidbody2D>().velocity.y);
        if (value > 0)
            GetComponent<Rigidbody2D>().velocity = new Vector3(value * speed, GetComponent<Rigidbody2D>().velocity.y);
        if (value < 0 && facingRight)
            Flip();
        if (value > 0 && !facingRight)
            Flip();

       // if (Mathf.Abs(value) > 0)


    }


    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    }
    protected  float  GetDirection()
    {
        orc_position = this.transform.localPosition;

        if (mode == Mode.Attack)
        {
            rabbit_position = Controler.lastRabit.transform.localPosition;
            if (orc_position.x < rabbit_position.x)
                return 1;
            else
                return -1;
        }

        if (mode == Mode.GoToA)
        {
            if (orc_position.x < pointA.x)
                return 1;
            else
                return -1;
        }

        if (mode == Mode.GoToB)
        {
            if (orc_position.x < pointB.x)
                return 1;
            else
                return -1;
        }
        return 0;
    }
    

    
}
