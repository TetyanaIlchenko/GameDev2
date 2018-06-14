using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Collectable
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
        if (rabit.HasDefaultSize)
        {
            rabit.Enlarge(2f);
        }
        LevelControler.current.AddMushrooms(1);
        CollectedHide();
    }
}
