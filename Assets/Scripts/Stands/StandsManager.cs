using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EFood
{
    CrumbSandwich,
    FriedEgg,
    Drink,
    Tequenos,
    HotDot,
    CaesarSalad,
    Empanada,
    MixedChowMein,
    Ramen,
    Hamburger
}

public class StandsManager : MonoBehaviour
{
    #region Public

    public void ResetStads()
    {
        foreach (IngredientStand ingredientStand in stands)
        {
            ingredientStand.isActivate = false;
        }
    }

    public void ReciveFoodType(EFood food)
    {
        switch (food)
        {
            case EFood.CrumbSandwich:
                ActivateStands(0);
                break;
            case EFood.FriedEgg:
                ActivateStands(1);
                break;
            case EFood.Drink:
                ActivateStands(2);
                break;
            case EFood.Tequenos:
                ActivateStands(3);
                break;
            case EFood.HotDot:
                ActivateStands(4);
                break;
            case EFood.CaesarSalad:
                ActivateStands(5);
                break;
            case EFood.Empanada:
                ActivateStands(6);
                break;
            case EFood.MixedChowMein:
                ActivateStands(7);
                break;
            case EFood.Ramen:
                ActivateStands(8);
                break;
            case EFood.Hamburger:
                ActivateStands(9);
                break;
        }
    }

    public UnityEvent ev_SetMaxIngredientsCount = new();

    #endregion

    #region Private

    private void ActivateStands(int index)
    {
        foreach (EIngredientType ingredientType in foodRecipes[index].recipe)
        {
            foreach (IngredientStand ingredientStand in stands)
            {
                if (ingredientStand.type == ingredientType)
                {
                    ingredientStand.isActivate = true;
                    ev_SetMaxIngredientsCount.Invoke();
                }
            }
        }
    }

    [SerializeField] private List<IngredientStand> stands;
    [SerializeField] private List<FoodRecipe> foodRecipes; 

    #endregion
}
