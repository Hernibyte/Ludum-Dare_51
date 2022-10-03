using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPlate : MonoBehaviour
{
    #region Public



    #endregion

    #region Private

    private void Awake()
    {
        orderWindow = FindObjectOfType<OrderWindow>();
        craftSystem = FindObjectOfType<CraftSystem>();
    }

    private void Update()
    {
        if (craftSystem.CompletedFood())
        {
            Debug.Log("Completed");
            if (!foodInstanciated)
            {
                Debug.Log("spawn comida");
                Debug.Log(orderWindow.foodMoneyGain);
                switch (orderWindow.foodMoneyGain)
                {
                    case EFood.CrumbSandwich:
                        foodInstance = Instantiate(foodItems[0], foodPosition.transform);
                        foodInstanciated = true;
                        break;
                    case EFood.FriedEgg:
                        foodInstance = Instantiate(foodItems[1], foodPosition.transform);
                        foodInstanciated = true;
                        break;
                    case EFood.Drink:
                        foodInstance = Instantiate(foodItems[2], foodPosition.transform);
                        foodInstanciated = true;
                        break;
                    case EFood.Tequenos:
                        foodInstance = Instantiate(foodItems[3], foodPosition.transform);
                        foodInstanciated = true;
                        break;
                    case EFood.HotDot:
                        foodInstance = Instantiate(foodItems[4], foodPosition.transform);
                        foodInstanciated = true;
                        break;
                    case EFood.CaesarSalad:
                        foodInstance = Instantiate(foodItems[5], foodPosition.transform);
                        foodInstanciated = true;
                        break;
                    case EFood.Empanada:
                        foodInstance = Instantiate(foodItems[6], foodPosition.transform);
                        foodInstanciated = true;
                        break;
                    case EFood.MixedChowMein:
                        foodInstance = Instantiate(foodItems[7], foodPosition.transform);
                        foodInstanciated = true;
                        break;
                    case EFood.Ramen:
                        foodInstance = Instantiate(foodItems[8], foodPosition.transform);
                        foodInstanciated = true;
                        break;
                    case EFood.Hamburger:
                        foodInstance = Instantiate(foodItems[9], foodPosition.transform);
                        foodInstanciated = true;
                        break;
                }
            }
        }
        else
        {
            if (foodInstance != null) Destroy(foodInstance);
            foodInstanciated = false;
            Debug.Log("No completed");
        }
    }

    private OrderWindow orderWindow;
    private CraftSystem craftSystem;
    private GameObject foodInstance;
    private bool foodInstanciated;
    
    [SerializeField] private GameObject foodPlateObj;
    [SerializeField] private GameObject foodPosition;

    [SerializeField] private List<GameObject> foodItems;

    #endregion
}
