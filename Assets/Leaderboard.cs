using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using LootLocker.Requests;
using TMPro;

//public class Leaderboard : MonoBehaviour
//{
//    int leaderboardID = 7684;
//    public TextMeshProUGUI playerNames;
//    public TextMeshProUGUI playerScores;


//    // Start is called before the first frame update
//    void Start()
//    {
     
//    }

//    public IEnumerator SubmitScoreRoutine(int scoreToUpload)
//    {
//        bool done = false;
//        string playerID = PlayerPrefs.GetString("PlayerID");
//        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardID, (response) =>
//        {
//            if (response.success){
//                Debug.Log("Succcessfully uploaded score");
//                done = true;
//            }
//            else{
//                Debug.Log("Failed" + response.Error);
//                done = true;
//            }
//        });
//        yield return new WaitWhile(() => done == false);
//    }

//    public IEnumerator FetchTopScoresRoutine()
//    {
//        bool done = false;

//        LootLockerSDKManager.GetScoreList(leaderboardID, 15, 0, (response) =>
//        {
//            if (response.success){
//                string tempPlayerNames = "Names\n";
//                string tempPlayerScore = "Score\n";

//                LootLockerLeaderboardMember[] members = response.items;

//                for (int i = 0; i < members.Length; i++){
//                    tempPlayerNames += members[i].rank + ".";
//                    if (members[i].player.name != ""){
//                        tempPlayerNames += members[i].player.name;
//                    }
//                    else{
//                        tempPlayerNames += members[i].player.id;
//                    }
//                    tempPlayerScore += members[i].score + "\n";
//                    tempPlayerNames += "\n";
//                }
//                done = true;
//                playerNames.text = tempPlayerNames;
//                playerScores.text = tempPlayerScore;
//            }
//            else{
//                Debug.Log("Failed" + response.Error);
//                done = true;
//            }
//        });
//        yield return new WaitWhile(() => done == false);

//    }

//}
