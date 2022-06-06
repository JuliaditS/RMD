using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int getStars;
    public int uang;


    #region Singleton
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {

            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }
    #endregion
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int getBintang(int levelNumber)
    {
        return PlayerPrefs.GetInt("SaveStars" + levelNumber);
    }

    public void SaveData(int levelNumber)
    {
        PlayerPrefs.SetInt("levelReach", levelNumber + 1);
        PlayerPrefs.SetInt("SaveUang", uang + PlayerPrefs.GetInt("SaveUang"));
        PlayerPrefs.SetInt("SaveStars" + levelNumber, getStars);
        PlayerPrefs.Save();
    }

    //
}
