﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Collectable
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void OnRabitHit(Controler rabit)
    {
        LevelControler.current.AddFruits(1);
        CollectedHide();
    }
}
