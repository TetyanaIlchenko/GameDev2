using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public Vector3 MoveBy;

    Vector3 pointA;
    Vector3 pointB;

    public float stop = 1f;
    public float speed = 1f;


    private bool goingToA = false;
    private float time_to_wait;


    // Use this for initialization
    void Start()
    {
        this.pointA = this.transform.position;
        this.pointB = this.pointA + MoveBy;
    }

    // Update is called once per frame
    void Update () {
        Vector3 my_pos = this.transform.position;
        Vector3 target;

        if (goingToA)
            target = pointA;
        else
            target = pointB;
        if (isArrived(my_pos, target))
        {
            time_to_wait -= Time.deltaTime;
            if (time_to_wait <= 0)
            {
                time_to_wait = stop;
                goingToA = !goingToA;
            }
        }
        else
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
    }
    bool isArrived(Vector3 pos, Vector3 target)
    {
        pos.z = 0;
        target.z = 0;
        return Vector3.Distance(pos, target) < 0.02f;
    }
}
