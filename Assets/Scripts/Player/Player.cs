using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Public

    [HideInInspector] public bool gameOver;
    public bool isDown = false;

    #endregion

    #region Private

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        movement = new PlayerMovement(rb, playerSpeed, playerMaxVelocity);
        playerInteraction = new PlayerInteraction(transform, usableObject, areaInteractionSize);
    }

    private void Update()
    {
        if (!gameOver && !isDown)
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
    }

    private void FixedUpdate()
    {
        if (!bodyAnimator.GetBool("IsDown")) isDown = false; 
        if (!gameOver && !isDown)
        {
            // player movement
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.D)) bodyTransform.rotation = Quaternion.Euler(0, 90, 0);
            else if (Input.GetKey(KeyCode.A)) bodyTransform.rotation = Quaternion.Euler(0, -90, 0);
            else if (Input.GetKey(KeyCode.W)) bodyTransform.rotation = Quaternion.Euler(0, 0, 0);
            else if (Input.GetKey(KeyCode.S)) bodyTransform.rotation = Quaternion.Euler(0, 180, 0);

            if (x != 0 || z != 0) 
                bodyAnimator.SetBool("IsRunning", true);
            else
                bodyAnimator.SetBool("IsRunning", false);


            movement.Move(new Vector3(x, 0, z));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IBanana iBanana;
        if (other.TryGetComponent<IBanana>(out iBanana))
        {
            isDown = true;
            bodyAnimator.SetBool("IsDown", isDown);
            Destroy(other.gameObject);
            movement.Zero();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, areaInteractionSize);
    }

    private PlayerMovement movement;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerMaxVelocity;
    private PlayerInteraction playerInteraction;
    [SerializeField] private float areaInteractionSize;
    [SerializeField] private LayerMask usableObject;
    private Rigidbody rb;
    [SerializeField] private Transform bodyTransform;
    [SerializeField] private Animator bodyAnimator;

    #endregion
}
