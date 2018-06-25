using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Collectable
{

    public float timeToSelfDestroy = 3f;

    private float direction;
    private bool fly = false;
    private float speed = 2;

    void Start()
    {
        StartCoroutine(DestroyLater());
    }

    void FixedUpdate()
    {
        if (fly)
        {
            this.transform.Translate((direction * speed * Time.deltaTime), 0, 0, Space.World);
        }
    }

    public void Launch(float direction)
    {
        this.direction = direction;
        fly = true;
    }

    IEnumerator DestroyLater()
    {
        yield return new WaitForSeconds(timeToSelfDestroy);
        Destroy(this.gameObject);
    }

    protected override void OnRabitHit(Controler rabit)
    {
        CollectedHide();
        if (rabit.IsDefenseless)
        {
            //           CollectedHide();
            if (!rabit.HasDefaultSize)
                rabit.Inlarge(1f);
            else
                rabit.Die();
        }
        //       rabit.Die();
    }
}
