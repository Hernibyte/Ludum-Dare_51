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

    public void GenerateNewOrder()
    {
        ev_RestartOrder.Invoke();

        int aux = Random.Range(0, 10);
        foodMoneyGain = (EFood)aux;

        orderTimer = 0;
        ev_NewOrder.Invoke(foodMoneyGain);
    }

    public UnityEvent ev_RestartOrder = new();
    public CustomEvents.Event_1efd ev_NewOrder = new();
    public CustomEvents.Event_1i ev_CompleteOrder = new();

    #endregion

    #region Private

    private void Update()
    {
        orderTimer += Time.deltaTime;
        if (orderTimer >= timePerOrder)
        {
            GenerateNewOrder();
        }
    }

    private EFood foodMoneyGain;
    private float orderTimer;
    [SerializeField]
    private float timePerOrder = 10;

    #endregion
}
