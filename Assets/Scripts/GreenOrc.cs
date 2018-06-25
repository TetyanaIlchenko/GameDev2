using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrc : Orc{
    private Animator greenOrcAnim = null;
    // Use this for initialization
    void Start () {
        greenOrcAnim = this.GetComponent<Animator>();
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
        //if (Controler.lastRabit.transform.parent == this.transform.parent)
       // {
            rabbit_position = Controler.lastRabit.transform.localPosition;
            orc_position = this.transform.localPosition;

            if (rabbit_position.x > Mathf.Min(pointA.x, pointB.x) && rabbit_position.x < Mathf.Max(pointA.x, pointB.x))
            {
                mode = Mode.Attack;
                Debug.Log("Is attacking");
            }
            //else
               // TurnOnWalkMode();
       // }
        //else
        //   TurnOnWalkMode();

        if (mode == Mode.Attack)
        {
            greenOrcAnim.SetBool("run", true);
            greenOrcAnim.SetBool("walk", false);
        }
        else
        {
            greenOrcAnim.SetBool("walk", true);
            greenOrcAnim.SetBool("run", false);
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

        if (Mathf.Abs(value) > 0)
        {
            greenOrcAnim.SetBool("walk", true);
        }

        else
            greenOrcAnim.SetBool("walk", false);

    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    }
    protected override float GetDirection()
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

    protected override void OnOrcDie(Controler rabit)
    {
        rabit.Jump();
        this.greenOrcAnim.SetTrigger("die");
        this.greenOrcAnim.SetBool("walk", false);
        this.greenOrcAnim.SetBool("run", false);
        Debug.Log("1");
         StartCoroutine(WaitForOrcDeathAnim());
    }
    /*
    protected override void OnRabitDie(HeroRabit rabit)
    {
        PlayAttackSound();
        this.orcAnim.SetTrigger("attack");

        if (rabit.IsDefenseless)
        {
            if (!rabit.HasDefaultSize)
                rabit.Inlarge(1f);
            else
                rabit.Die();
        }
        //      rabit.Die();
    }*/

    protected virtual IEnumerator WaitForOrcDeathAnim()
    {
        yield return new WaitForSeconds(greenOrcAnim.GetCurrentAnimatorStateInfo(0).length);
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collider)
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
    }
}
