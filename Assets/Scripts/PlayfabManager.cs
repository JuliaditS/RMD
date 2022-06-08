using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Login();
        GetUserDat();
    }

    // Update is called once per frame
    void Login() {
        var request = new LoginWithCustomIDRequest {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void GetUserDat(){
        int bintang=0,uang=0,level=0;
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), 
        result=>{
            Debug.Log("Recieved user data!");
            if (result.Data != null){
                uang=int.Parse(result.Data["SaveUang"].Value);
                level=int.Parse(result.Data["levelReach"].Value);
                Debug.Log(level);
                for (int i=1;i<level;i++){
                    bintang=int.Parse(result.Data["SaveStars" + i].Value);
                    Debug.Log(bintang);
                    PlayerPrefs.SetInt("SaveStars" + i, bintang);
                }
            }else 
                Debug.Log("No Data");
        }, OnError);

        PlayerPrefs.SetInt("levelReach", level);
        PlayerPrefs.SetInt("SaveUang", uang);
        PlayerPrefs.Save();
    }

    void OnSuccess(LoginResult result) {
        Debug.Log("Successful login/account create!");
    }

    void OnError(PlayFabError error) {
        Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }
}
