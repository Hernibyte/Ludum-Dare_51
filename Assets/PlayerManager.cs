using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public Leaderboard leaderboard;
    public TMP_InputField playerNameField;

    // Start is called before the first frame update
    void Start(){
        StartCoroutine(SetupRoutine());
    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameField.text, (response) =>
        {
            if (response.success){
                Debug.Log("Succesfully set player namee");
            }
            else{
                Debug.Log("Could not set player name" + response.Error);
            }
        });
    }

    IEnumerator SetupRoutine()
    {
        yield return LogInRoutine();
        yield return leaderboard.FetchTopScoresRoutine();
    }

    IEnumerator LogInRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Cannot start session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
