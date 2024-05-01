using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float moveSpeed;
    public float leftAngle;
    public float rightAngle;

    bool moveClockWise;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        moveClockWise = true;
    }

    // Update is called once per frame
    void Update()
    {

        Move();

    }
    public void ChangeMoveDir()
    {
        if (transform.rotation.z > rightAngle)
        {
            moveClockWise = true;
        }
        if (transform.rotation.z < leftAngle)
        {
            moveClockWise= false;
        }
    }
    public void Move()
    {
        ChangeMoveDir();
        if(moveClockWise)
        {
            rb2d.angularVelocity = -1* moveSpeed;
        }
        if (!moveClockWise)
        {
            rb2d.angularVelocity = moveSpeed;

        }
    }
}
