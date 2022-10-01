using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Public

    public int playerMoney = 0;
    public int playerTolerance = 10;

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
        orderWindow.ev_NewOrder.AddListener((EFood food) =>
        {
            standsManager.ReciveFoodType(food);
            if (!firstGeneration) playerTolerance--;
            else firstGeneration = false;
        });
        orderWindow.ev_CompleteOrder.AddListener((int moneyGain) =>
        {
            if (craftSystem.CompletedFood())
            {
                playerMoney += moneyGain;
                orderWindow.GenerateNewOrder();
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

    private bool firstGeneration = true;

    #endregion
}
