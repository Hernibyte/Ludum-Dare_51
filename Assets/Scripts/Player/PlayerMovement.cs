using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerMovement
{
    #region Constructors

    public PlayerMovement(Rigidbody rigidbody, float speed)
    {
        this.rigidbody = rigidbody;
        this.speed = speed;
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
    }

    #endregion

    #region Private

    private Rigidbody rigidbody;
    private float speed;

    #endregion
}
