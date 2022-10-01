using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OrderWindow : MonoBehaviour, IUsable
{
    #region Public

    public void Action()
    {
        ev_CompleteOrder.Invoke();
    }

    public CustomEvents.Event_1i ev_NewOrder = new();
    public UnityEvent ev_CompleteOrder = new();

    #endregion

    #region Private

    private void Update()
    {
        orderTimer += Time.deltaTime;
        if (orderTimer >= timePerOrder)
        {
            orderTimer = 0;
            ev_NewOrder.Invoke(Random.Range(1, 3));
        }
    }

    private float orderTimer;
    [SerializeField]
    private float timePerOrder = 10;

    #endregion
}
