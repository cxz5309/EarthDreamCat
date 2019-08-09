using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    public Transform stageSliderLeft;
    public Transform stageSliderRight;
    public Transform stageSliderPointer;

    private void Start()
    {
        stageSliderPointer.position = stageSliderLeft.position;
    }

    IEnumerator coStageSlider()
    {
        yield return new WaitForFixedUpdate();
    }

    public void SliderFill()
    {
        stageSliderPointer.position = Vector2.MoveTowards(stageSliderPointer.transform.position, stageSliderRight.position, Time.deltaTime/NoteManager.instance.endTime);
    }
}
