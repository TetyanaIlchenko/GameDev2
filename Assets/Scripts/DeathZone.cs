﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Controler rabbit = collider.GetComponent<Controler>();
        if (rabbit != null)
        {
            LevelControler.current.RabbitDeath(rabbit);
        }
    }
}
