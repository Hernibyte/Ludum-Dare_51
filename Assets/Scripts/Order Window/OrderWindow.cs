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

    public UnityEvent ev_RestartOrder = new();
    public CustomEvents.Event_1efd ev_NewOrder = new();
    public UnityEvent ev_CompleteOrder = new();

    #endregion

    #region Private

    private void Update()
    {
        orderTimer += Time.deltaTime;
        if (orderTimer >= timePerOrder)
        {
            ev_RestartOrder.Invoke();

            int aux = Random.Range(0, 10);

            orderTimer = 0;
            ev_NewOrder.Invoke((EFood)aux);
        }
    }

    private float orderTimer;
    [SerializeField]
    private float timePerOrder = 10;

    #endregion
}
