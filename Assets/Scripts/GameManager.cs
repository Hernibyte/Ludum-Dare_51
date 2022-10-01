using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Public



    #endregion

    #region Private

    private void Awake()
    {
        orderWindow = FindObjectOfType<OrderWindow>();
        craftSystem = FindObjectOfType<CraftSystem>();
        ingredientStands = FindObjectsOfType<IngredientStand>();
    }

    private void Start()
    {
        orderWindow.ev_NewOrder.AddListener(craftSystem.SetMaxCount);
        orderWindow.ev_CompleteOrder.AddListener(() =>
        {
            if (craftSystem.CompletedFood())
            {
                Debug.Log("complete");
            }
        });

        foreach (IngredientStand ingredientStand in ingredientStands)
        {
            ingredientStand.getIngredient.AddListener(craftSystem.AddIngredient);
        }
    }

    private OrderWindow orderWindow;
    private CraftSystem craftSystem;
    private IngredientStand[] ingredientStands;

    #endregion
}
