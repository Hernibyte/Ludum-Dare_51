using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Public



    #endregion

    #region Private

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        movement = new PlayerMovement(rb, playerSpeed);
    }

    private void FixedUpdate()
    {
        // player movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movement.Move(new Vector3(x, 0, z));
    }

    [SerializeField] private PlayerMovement movement;
    [SerializeField] private float playerSpeed;
    private Rigidbody rb;

    #endregion
}
