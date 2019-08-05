using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;

    public Image healthBarSlider;
    public Animator playerAnimator;

    public float curHealthPoint;
    public float maxHealthPoint;
    


    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        maxHealthPoint = 80;
        curHealthPoint = 80;  // 시작 HP
    }

    public void GetDamage(float damage)
    {
        curHealthPoint -= damage;

        if (curHealthPoint <= 0)
        {
            curHealthPoint = 0;
            //GameManager.instance.GameOver();
        }
        SetHealthBarUI();
    }
    public void SetHealthBarUI()
    {
        healthBarSlider.fillAmount = curHealthPoint / maxHealthPoint;
    }
    public void SetPlayerAnimator(string behavior)
    {
        playerAnimator.SetTrigger(behavior);
    }
}
