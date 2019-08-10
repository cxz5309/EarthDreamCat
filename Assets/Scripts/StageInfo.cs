using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StageInfo : MonoBehaviour
{
    public string stageName;
    public string stageBGM;
    public int highScore;
    public int highCombo;

    void Start()
    {
        highScore = PlayerPrefs.GetInt(stageName + "Score");
        highCombo = PlayerPrefs.GetInt(stageName + "Combo");

        if (PlayerPrefs.GetInt(stageName + "Score") == 0)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
