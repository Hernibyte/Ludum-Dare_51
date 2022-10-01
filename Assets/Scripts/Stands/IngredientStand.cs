using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IngredientStand : MonoBehaviour, IUsable
{
    #region Public

    public bool isActivate;

    [HideInInspector]
    public UnityEvent getIngredient = new UnityEvent();

    public void Action()
    {
        if (isActivate)
        {
            getIngredient.Invoke();
            isActivate = false;
        }
    }

    #endregion
}
