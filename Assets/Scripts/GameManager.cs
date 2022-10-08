using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Public

    public Leaderboard leaderboard;

    public void ResumeGame()
    {
        inPause = false;
        player.inPause = inPause;
        orderWindow.inPause = inPause;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public bool inPause;

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
        bananasManager = FindObjectOfType<BananasManager>();
    }

    private void Start()
    {
        orderWindow.ev_RestartOrder.AddListener(craftSystem.RestartCount);
        orderWindow.ev_RestartOrder.AddListener(standsManager.ResetStads);
        orderWindow.ev_NewOrder.AddListener((EFood food) =>
        {
            bananasManager.NewBanana();
            standsManager.ReciveFoodType(food);
            if (!firstGeneration) { playerTolerance--; ev_ResTolerance.Invoke(); }
            else firstGeneration = false;

            if (playerTolerance <= 0)
            {
                ev_GameOver.Invoke();
                player.gameOver = true;
                orderWindow.gameOver = true;
                StartCoroutine(leaderboard.SubmitScoreRoutine(playerMoney));
                LostGame();
            }
        });
        orderWindow.ev_OtherOrder.AddListener((EFood food) =>
        {
            bananasManager.NewBanana();
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inPause = true;
            player.inPause = inPause;
            orderWindow.inPause = inPause;
        }
    }

    IEnumerator LostGame()
    {
        yield return new WaitForSecondsRealtime(1f);
        yield return leaderboard.SubmitScoreRoutine(playerMoney);
    }

    private OrderWindow orderWindow;
    private CraftSystem craftSystem;
    private StandsManager standsManager;
    private IngredientStand[] ingredientStands;
    private Player player;
    private BananasManager bananasManager;

    #endregion
}
