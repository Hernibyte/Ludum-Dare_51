using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerInteraction
{
    #region Constructors

    public PlayerInteraction(Transform transform, LayerMask usableObject, float areaInteractionSize)
    {
        this.transform = transform;
        this.usableObject = usableObject;
        this.areaInteractionSize = areaInteractionSize;
    }

    #endregion

    #region Public

    /// <summary>
    /// Interact with the environment
    /// </summary>
    /// <returns>Usable objects interfaces</returns>
    public IUsable Interact()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, areaInteractionSize, usableObject);

        foreach (Collider collider in colliders)
        {
            IUsable usable;
            if (collider.TryGetComponent<IUsable>(out usable))
            {
                return usable;
            }
        }

        return null;
    }

    #endregion

    #region Private

    private float areaInteractionSize;
    private Transform transform;
    private LayerMask usableObject;

    #endregion
}
