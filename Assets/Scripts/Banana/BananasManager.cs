using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananasManager : MonoBehaviour
{
    #region Public

    public void NewBanana()
    {
        int ran = Random.Range(0, 7);
        if (bananaSpon != null ) { Destroy(bananaSpon); }
        bananaSpon = Instantiate(bananaPrefab, spawnPoints[ran]);
    }

    #endregion

    #region Private

    private GameObject bananaSpon;

    [SerializeField] private GameObject bananaPrefab;
    [SerializeField] private List<Transform> spawnPoints;

    #endregion
}
