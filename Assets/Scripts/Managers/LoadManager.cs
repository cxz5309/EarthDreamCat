using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    public GameObject audioManager;
    //public GameObject stageManager;


    private void Awake()
    {
        if (AudioManager.instance == null)
        {
            Instantiate(audioManager);
        }
        //if (StageManager.instance == null)
        //{
        //    Instantiate(stageManager);
        //}
    }
}