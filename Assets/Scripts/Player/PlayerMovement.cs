using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerMovement
{
    #region Constructors

    public PlayerMovement(Rigidbody rigidbody, float speed, float maxVelocity)
    {
        this.rigidbody = rigidbody;
        this.speed = speed;
        this.maxVelocity = maxVelocity;
    }

    #endregion

    #region Public

    /// <summary>
    /// Move the player
    /// </summary>
    /// <param name="direction"></param>
    public void Move(Vector3 direction)
    {
        rigidbody.AddForce(direction * speed);
        
        Vector3 newVel = rigidbody.velocity;

        // clamp
        if (newVel.x >= maxVelocity) newVel.x = maxVelocity;
        if (newVel.x <= -maxVelocity) newVel.x = -maxVelocity;

        if (newVel.y >= maxVelocity) newVel.y = maxVelocity;
        if (newVel.y <= -maxVelocity) newVel.y = -maxVelocity;

        if (newVel.z >= maxVelocity) newVel.z = maxVelocity;
        if (newVel.z <= -maxVelocity) newVel.z = -maxVelocity;

        rigidbody.velocity = newVel;
    }

    public void Zero()
    {
        rigidbody.velocity = Vector3.zero;
    }

    #endregion

    #region Private

    private Rigidbody rigidbody;
    private float speed;
    private float maxVelocity;

    #endregion
}
