using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour {

    public enum Mode
    {
        GoToA,
        GoToB,
        Attack
    }

    protected Rigidbody2D orcRigidBody = null;
    protected Animator orcAnim = null;
    protected SpriteRenderer orcSpriteRenderer;

    public float speed = 2f;
    public Vector3 pointA;
    public Vector3 pointB;
    public bool facingRight = false;

    protected Mode mode;
    protected Vector3 rabbit_position;
    protected Vector3 orc_position;

    // Use this for initialization
    void Start () {
        orcRigidBody = this.GetComponent<Rigidbody2D>();
        orcAnim = this.GetComponent<Animator>();
        orcSpriteRenderer = this.GetComponent<SpriteRenderer>();
        mode = Mode.GoToA;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
     void FixedUpdate()
    {
        speed = Input.GetAxis("Horizontal");
        if (speed < 0)
            GetComponent<Rigidbody2D>().velocity = new Vector3(speed * 2f, GetComponent<Rigidbody2D>().velocity.y);
        if (speed > 0)
            GetComponent<Rigidbody2D>().velocity = new Vector3(speed * 2f, GetComponent<Rigidbody2D>().velocity.y);

        if (speed < 0 && facingRight)
            Flip();
        if (speed > 0 && !facingRight)
            Flip();
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    }

    protected virtual float GetDirection()
    {
        return 0;
    }

    protected virtual bool IsArrived(Vector3 point)
    {
        return Mathf.Abs(this.transform.localPosition.x - point.x) < 0.02f;
    }

  /*  void OnCollisionEnter2D(Collision2D collider)
    {
        Controler rabit = collider.gameObject.GetComponent<Controler>();
        if (rabit != null)
        {
            Debug.Log("Hit rabit");
            if ((rabit.transform.position.y - this.transform.position.y) > 0.6f)
                OnOrcDie(rabit);
            else
            {
                OnRabitDie(rabit);
            }
        }
    }*/

    protected virtual void OnOrcDie(Controler rabit)
    {
    }

    protected virtual void OnRabitDie(Controler rabit)
    {
    }

    
}
