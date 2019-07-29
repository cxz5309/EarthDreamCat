using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlManager : MonoBehaviour
{
    public enum judges { NONE = 0, PERFECT, GOOD, MISS };
    private GameObject thisEnemy;
    public GameObject judgeUI;
    private EnemyInfo.Type thisType;
    public judges judge;
    public Animator playerAnimator;
    public Animator judgeUIAnimator;
    public Animator comboUIAnimator;
    public Sprite[] judgeUISprites;
    public Text comboText;
    public Text scoreText;

    public int combo { get; set; }
    public int maxCombo { get; set; }
    public int score { get; set; }
    public int[] judgeNum = new int[3];

    #region
    private KeyCode keyCode;
    #endregion
    public static ControlManager instance;

    public string button;
    private AudioManager theAudio;


    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        maxCombo = 0;
        theAudio = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        #region
        if (thisEnemy != null)
        {
            thisType = thisEnemy.GetComponent<EnemyInfo>().type;
            switch (thisType)
            {
                case EnemyInfo.Type.HighMonster:
                    keyCode = KeyCode.Q;
                    break;
                case EnemyInfo.Type.HighAttack:
                    keyCode = KeyCode.W;
                    break;
                case EnemyInfo.Type.LowAttack:
                    keyCode = KeyCode.E;
                    break;
                case EnemyInfo.Type.LowMonster:
                    keyCode = KeyCode.R;
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            theAudio.Play(button);
            playerAnimator.SetTrigger("punchTrigger");
            if (KeyCode.Q == keyCode)
            {
                if (thisEnemy != null)
                {
                    OnHitEffect(thisEnemy.transform);
                    ProcessCombo();
                    ProcessJudge(judge);
                    ProcessScore(judge);
                    thisEnemy.SetActive(false);
                    thisEnemy = null;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            theAudio.Play(button);
            playerAnimator.SetTrigger("avoidTrigger");
            if (KeyCode.W == keyCode)
            {
                if (thisEnemy != null)
                {
                    OnHitEffect(thisEnemy.transform);
                    ProcessCombo();
                    ProcessJudge(judge);
                    ProcessScore(judge);
                    thisEnemy.SetActive(false);
                    thisEnemy = null;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            theAudio.Play(button);
            playerAnimator.SetTrigger("guardTrigger");
            if (KeyCode.E == keyCode)
            {
                if (thisEnemy != null)
                {
                    OnHitEffect(thisEnemy.transform);
                    ProcessCombo();
                    ProcessJudge(judge);
                    ProcessScore(judge);
                    thisEnemy.SetActive(false);
                    thisEnemy = null;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            theAudio.Play(button);
            playerAnimator.SetTrigger("attackTrigger");
            if (KeyCode.R == keyCode)
            {
                if (thisEnemy != null)
                {
                    OnHitEffect(thisEnemy.transform);
                    ProcessCombo();
                    ProcessJudge(judge);
                    ProcessScore(judge);
                    thisEnemy.SetActive(false);
                    thisEnemy = null;
                }
            }
        }
        #endregion
    }

    public void GetThisEnemy(GameObject thisEnemy)
    {
        this.thisEnemy = thisEnemy;
    }

    public void ProcessJudge(judges judge)
    {
        Image judgeUIImage = judgeUI.GetComponent<Image>();
        judgeUIImage.sprite = judgeUISprites[(int)judge - 1];
        judgeUIAnimator.SetTrigger("judgeTrigger");
        judgeNum[(int)judge-1]++;
    }

    public void ProcessCombo()
    {
        combo++;
        comboText.text = combo + " Combo";
        comboUIAnimator.SetTrigger("comboTrigger");
        if (maxCombo < combo)
        {
            maxCombo = combo;
        }
    }

    public void OnHitEffect(Transform tf)
    {
        GameObject effectObj = ObjectPoolContainer.Instance.Pop("HitEffect");
        effectObj.transform.position.Set(tf.position.x, tf.position.y, tf.position.z-10f);
        effectObj.SetActive(true);
    }

    public void DestroyCombo()
    {
        combo = 0;
        comboText.text = "";
    }

    public void ProcessScore(judges judge)
    {
        if (judge == judges.PERFECT)
        {
            score += 300;
        }
        else if(judge == judges.GOOD)
        {
            score += 200;
        }
        scoreText.text = score.ToString();
    }
    //public void onRedClick()
    //{
    //    if (thisEnemy != null)
    //    {
    //        thisType = thisEnemy.GetComponent<EnemyInfo>().type;
    //        if (thisType == EnemyInfo.Type.HighMonster)
    //        {
    //            Debug.Log(1);
    //            Debug.Log(judge);
    //            thisEnemy.SetActive(false);
    //        }
    //    }
    //}

    //public void onYellowClick()
    //{
    //    if (thisEnemy!=null)
    //    {
    //        thisType = thisEnemy.GetComponent<EnemyInfo>().type;
    //        if (thisType == EnemyInfo.Type.HighAttack)
    //        {
    //            Debug.Log(2);
    //            Debug.Log(judge);
    //            thisEnemy.SetActive(false);
    //        }
    //    }
    //}
    //public void onGreenClick()
    //{
    //    if (thisEnemy != null)
    //    {
    //        thisType = thisEnemy.GetComponent<EnemyInfo>().type;
    //        if (thisType == EnemyInfo.Type.LowAttack)
    //        {
    //            Debug.Log(3);
    //            Debug.Log(judge);
    //            thisEnemy.SetActive(false);
    //        }
    //    }
    //}
    //public void onBlueClick()
    //{
    //    if (thisEnemy != null)
    //    {
    //        thisType = thisEnemy.GetComponent<EnemyInfo>().type;
    //        if (thisType == EnemyInfo.Type.LowMonster)
    //        {
    //            Debug.Log(4);
    //            Debug.Log(judge);
    //            thisEnemy.SetActive(false);
    //        }
    //    }
    //}
}
