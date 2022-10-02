using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Public



    #endregion

    #region Private

    private void ResTolerance()
    {
        toleranceImage.transform.localScale = new Vector3(toleranceImage.transform.localScale.x - toleranceRes, 1, 1);
    }

    private void Awake()
    {
        orderWindow = FindObjectOfType<OrderWindow>();
        gameManager = FindObjectOfType<GameManager>();

        toleranceRes = 1.0f / gameManager.playerTolerance;
        gameManager.ev_ResTolerance.AddListener(ResTolerance);
    }

    private void Update()
    {
        moneyCount.text = gameManager.playerMoney.ToString();

        if (gameManager.firstGeneration)
            startGameTimer.text = ((int)(orderWindow.timePerOrder - orderWindow.orderTimer)).ToString();
        else
        {
            if (startGameTimer.IsActive()) startGameTimer.gameObject.SetActive(false);
            gameTimer.text = ((int)(orderWindow.timePerOrder - orderWindow.orderTimer)).ToString();
        }
    }

    private OrderWindow orderWindow;
    private GameManager gameManager;

    [SerializeField] private TextMeshProUGUI moneyCount;
    [SerializeField] private TextMeshProUGUI gameTimer;
    [SerializeField] private TextMeshProUGUI startGameTimer;

    [SerializeField] private Image toleranceImage;
    private float toleranceRes;

    #endregion
}
