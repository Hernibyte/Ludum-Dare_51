using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandTrailBehaviour : MonoBehaviour
{
    #region Public

    public bool isActive;

    #endregion

    #region Private

    private void Update()
    {
        if (isActive)
        {
            transform.RotateAround(transform.parent.position, transform.parent.up, 90f * Time.deltaTime);
        }
    }

    #endregion
}
