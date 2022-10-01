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
        playerInteraction = new PlayerInteraction(transform, usableObject, areaInteractionSize);
    }

    private void Update()
    {
        IUsable usable = playerInteraction.Interact();

        if (usable != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                usable.Action();
            }
        }
    }

    private void FixedUpdate()
    {
        // player movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movement.Move(new Vector3(x, 0, z));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, areaInteractionSize);
    }

    [SerializeField] private float playerSpeed;
    private PlayerMovement movement;
    private PlayerInteraction playerInteraction;
    [SerializeField] private float areaInteractionSize;
    [SerializeField] private LayerMask usableObject;
    private Rigidbody rb;

    #endregion
}
