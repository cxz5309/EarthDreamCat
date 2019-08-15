using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectManager : MonoBehaviour
{
    public GameObject StageList;

    Vector2 nextPos;

    private int distance;
    private int speed = 5;
    private int stageIndex;
    public GameObject []stageArr;

    void Start()
    {
        stageIndex = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Left();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Rignt();
        }

        StageList.transform.localPosition = Vector2.Lerp(StageList.transform.localPosition, nextPos, Time.deltaTime * speed);
    }

    public void Left()
    {
        stageIndex += 1;
        if (stageIndex >= stageArr.Length)
        {
            stageIndex = stageArr.Length - 1;
            return;
        }
        distance -= 250;
        nextPos = new Vector2(distance, StageList.transform.localPosition.y);
    }

    public void Rignt()
    {
        stageIndex -= 1;
        if (stageIndex < 0)
        {
            stageIndex = 0;
            return;
        }
        distance += 250;
        nextPos = new Vector2(distance, StageList.transform.localPosition.y);
    }
}