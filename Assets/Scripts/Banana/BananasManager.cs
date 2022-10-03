using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananasManager : MonoBehaviour
{
    #region Public

    public void SwitchActivate(bool value)
    {
        isActivate = !isActivate;
    }

    public void NewBanana()
    {
        if (isActivate)
        {
            int ran = Random.Range(0, 7);
            if (bananaSpon != null) { Destroy(bananaSpon); }
            bananaSpon = Instantiate(bananaPrefab, spawnPoints[ran]);
        }
        else
        {
            if (bananaSpon != null) { Destroy (bananaSpon); }
        }
    }

    #endregion

    #region Private

    private GameObject bananaSpon;
    private bool isActivate = true;

    [SerializeField] private GameObject bananaPrefab;
    [SerializeField] private List<Transform> spawnPoints;

    #endregion
}
