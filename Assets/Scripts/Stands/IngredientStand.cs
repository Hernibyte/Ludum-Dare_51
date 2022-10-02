using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public enum EIngredientType
{
    Bread,
    Cheese,
    Ham,
    Egg,
    CokingOil,
    Water,
    TeaBag,
    Flour,
    Vegetable,
    Lettuce,
    Tomatoes,
    Meat,
    Dressing,
    Sausage,
    Noodles
}

public class IngredientStand : MonoBehaviour, IUsable
{
    #region Public

    public void Action()
    {
        if (isActivate)
        {
            getIngredient.Invoke();
            isActivate = false;
        }
    }

    [HideInInspector]
    public UnityEvent getIngredient = new UnityEvent();
    public bool isActivate;
    public EIngredientType type;

    #endregion

    #region Private

    private void Awake()
    {
        trailEffect = GetComponentInChildren<StandTrailBehaviour>();
    }

    private void Update()
    {
        trailEffect.isActive = isActivate;
    }

    [SerializeField] private StandTrailBehaviour trailEffect;

    #endregion
}
