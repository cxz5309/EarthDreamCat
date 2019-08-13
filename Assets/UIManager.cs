using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    public Slider stageSlider;

    private void Start()
    {
        StartCoroutine(coStageSlider());
    }

    IEnumerator coStageSlider()
    {
        float time = 0;
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.05f);
        while (time < NoteManager.instance.endTime)
        {
            SliderFill();
            time += 0.05f;
            yield return waitForSeconds;
        }
    }

    public void SliderFill()
    {
        stageSlider.value += 1/(NoteManager.instance.endTime*20);
    }

}
