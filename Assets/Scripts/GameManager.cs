using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Public

    public void ReloadScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public int playerMoney = 0;
    public int playerTolerance = 10;

    public UnityEvent ev_GameOver = new();
    public UnityEvent ev_ResTolerance = new();

    [HideInInspector] public bool firstGeneration = true;

    #endregion

    #region Private

    private void Awake()
    {
        orderWindow = FindObjectOfType<OrderWindow>();
        craftSystem = FindObjectOfType<CraftSystem>();
        ingredientStands = FindObjectsOfType<IngredientStand>();
        standsManager = FindObjectOfType<StandsManager>();
        player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        orderWindow.ev_RestartOrder.AddListener(craftSystem.RestartCount);
        orderWindow.ev_RestartOrder.AddListener(standsManager.ResetStads);
        orderWindow.ev_NewOrder.AddListener((EFood food) =>
        {
            Debug.Log(food);

            standsManager.ReciveFoodType(food);
            if (!firstGeneration) { playerTolerance--; ev_ResTolerance.Invoke(); }
            else firstGeneration = false;

            if (playerTolerance <= 0)
            {
                ev_GameOver.Invoke();
                player.gameOver = true;
                orderWindow.gameOver = true;
            }
        });
        orderWindow.ev_OtherOrder.AddListener((EFood food) =>
        {
            standsManager.ReciveFoodType(food);
        });
        orderWindow.ev_CompleteOrder.AddListener((int moneyGain) =>
        {
            if (craftSystem.CompletedFood())
            {
                playerMoney += moneyGain;
                orderWindow.GenerateOtherOrder();
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
    private Player player;

    #endregion
}
