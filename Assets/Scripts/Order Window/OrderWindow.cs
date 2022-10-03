using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OrderWindow : MonoBehaviour, IUsable
{
    #region Public

    public void Action()
    {
        switch (foodMoneyGain)
        {
            case EFood.CrumbSandwich:
                ev_CompleteOrder.Invoke(7);
                break;
            case EFood.FriedEgg:
                ev_CompleteOrder.Invoke(5);
                break;
            case EFood.Drink:
                ev_CompleteOrder.Invoke(5);
                break;
            case EFood.Tequenos:
                ev_CompleteOrder.Invoke(7);
                break;
            case EFood.HotDot:
                ev_CompleteOrder.Invoke(8);
                break;
            case EFood.CaesarSalad:
                ev_CompleteOrder.Invoke(11);
                break;
            case EFood.Empanada:
                ev_CompleteOrder.Invoke(8);
                break;
            case EFood.MixedChowMein:
                ev_CompleteOrder.Invoke(13);
                break;
            case EFood.Ramen:
                ev_CompleteOrder.Invoke(16);
                break;
            case EFood.Hamburger:
                ev_CompleteOrder.Invoke(20);
                break;
        }
    }

    public bool IsUsable()
    {
        return true;
    }

    public void GenerateNewOrder()
    {
        ev_RestartOrder.Invoke();

        int aux = Random.Range(0, 10);
        foodMoneyGain = (EFood)aux;

        orderTimer = 0;
        ev_NewOrder.Invoke(foodMoneyGain);
    }

    public void GenerateOtherOrder()
    {
        ev_RestartOrder.Invoke();

        int aux = Random.Range(0, 10);
        foodMoneyGain = (EFood)aux;

        orderTimer = 0;
        ev_OtherOrder.Invoke(foodMoneyGain);
    }

    public float orderTimer { get; private set; }
    public float timePerOrder = 10;

    public bool gameOver;
    public bool inPause;
    public EFood foodMoneyGain;

    public UnityEvent ev_RestartOrder = new();
    public CustomEvents.Event_1efd ev_NewOrder = new();
    public CustomEvents.Event_1efd ev_OtherOrder = new();
    public CustomEvents.Event_1i ev_CompleteOrder = new();

    #endregion

    #region Private

    private void Update()
    {
        if (!gameOver && !inPause)
        {
            orderTimer += Time.deltaTime;
            if (orderTimer >= timePerOrder)
            {
                GenerateNewOrder();
            }
        }
    }


    #endregion
}
