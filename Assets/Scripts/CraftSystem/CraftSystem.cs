using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSystem : MonoBehaviour
{
    #region Public

    public void SetMaxCount(int maxCount)
    {
        ingredientsCount = 0;
        ingredientsMaxCount = maxCount;
    }

    public void AddIngredient()
    {
        ingredientsCount++;
    }

    public bool CompletedFood()
    {
        if (ingredientsCount >= ingredientsMaxCount)
        {
            return true;
        }
        return false;
    }

    #endregion

    #region Private

    [SerializeField]
    private int ingredientsMaxCount;
    [SerializeField]
    private int ingredientsCount;

    #endregion
}
