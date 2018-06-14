using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    //	private bool hideAnimation = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void OnRabitHit(Controler rabbit)
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //	if(!this.hideAnimation) {
        Controler rabbit = collider.GetComponent<Controler>();
        if (rabbit != null)
        {
            OnRabitHit(rabbit);
        }
        //		}
    }

    protected virtual void CollectedHide()
    {
        Destroy(this.gameObject);
    }

    
}
