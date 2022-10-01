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
        standsManager = FindObjectOfType<StandsManager>();
    }

    private void Start()
    {
        orderWindow.ev_RestartOrder.AddListener(craftSystem.RestartCount);
        orderWindow.ev_RestartOrder.AddListener(standsManager.ResetStads);
        orderWindow.ev_NewOrder.AddListener(standsManager.ReciveFoodType);
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

        standsManager.ev_SetMaxIngredientsCount.AddListener(craftSystem.AddMaxCount);
    }

    private OrderWindow orderWindow;
    private CraftSystem craftSystem;
    private StandsManager standsManager;
    private IngredientStand[] ingredientStands;

    #endregion
}
