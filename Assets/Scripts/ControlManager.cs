using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlManager : MonoBehaviour
{
    public enum judges { NONE = 0, PERFECT, GOOD, MISS };
    private GameObject[] thisEnemy = new GameObject[4];
    public GameObject judgeUI;
    public judges judge;
    public Animator judgeUIAnimator;
    public Animator comboUIAnimator;
    public Sprite[] judgeUISprites;
    public Text comboText;
    public Text scoreText;
    
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
        Results.maxCombo = 0;
        theAudio = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        #region
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            theAudio.Play(button);
            PlayerInfo.instance.SetPlayerAnimator("punchTrigger");
            {
                if (thisEnemy[0] != null)
                {
                    OnHitEffect(thisEnemy[0].transform);
                    ProcessCombo();
                    ProcessJudge(judge);
                    ProcessScore(judge);
                    thisEnemy[0].SetActive(false);
                    thisEnemy[0] = null;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            theAudio.Play(button);
            PlayerInfo.instance.SetPlayerAnimator("avoidTrigger");
            {
                if (thisEnemy[1] != null)
                {
                    OnHitEffect(thisEnemy[1].transform);
                    ProcessCombo();
                    ProcessJudge(judge);
                    ProcessScore(judge);
                    thisEnemy[1].SetActive(false);
                    thisEnemy[1] = null;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            theAudio.Play(button);
            PlayerInfo.instance.SetPlayerAnimator("guardTrigger");
            {
                if (thisEnemy[2] != null)
                {
                    OnHitEffect(thisEnemy[2].transform);
                    ProcessCombo();
                    ProcessJudge(judge);
                    ProcessScore(judge);
                    thisEnemy[2].SetActive(false);
                    thisEnemy[2] = null;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            theAudio.Play(button);
            PlayerInfo.instance.SetPlayerAnimator("attackTrigger");
            {
                if (thisEnemy[3] != null)
                {
                    OnHitEffect(thisEnemy[3].transform);
                    ProcessCombo();
                    ProcessJudge(judge);
                    ProcessScore(judge);
                    thisEnemy[3].SetActive(false);
                    thisEnemy[3] = null;
                }
            }
        }
        #endregion
    }

    public void GetThisEnemy(GameObject thisEnemy, int type)
    {
        this.thisEnemy[type] = thisEnemy;
    }

    public void ProcessJudge(judges judge)
    {
        Image judgeUIImage = judgeUI.GetComponent<Image>();
        judgeUIImage.sprite = judgeUISprites[(int)judge - 1];
        judgeUIAnimator.SetTrigger("judgeTrigger");
        Results.judgeNum[(int)judge-1]++;
    }

    public void ProcessCombo()
    {
        Results.combo++;
        comboText.text = Results.combo + " Combo";
        comboUIAnimator.SetTrigger("comboTrigger");
        if (Results.maxCombo < Results.combo)
        {
            Results.maxCombo = Results.combo;
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
        Results.combo = 0;
        comboText.text = "";
    }

    public void ProcessScore(judges judge)
    {
        if (judge == judges.PERFECT)
        {
            Results.score += 300;
        }
        else if(judge == judges.GOOD)
        {
            Results.score += 200;
        }
        scoreText.text = Results.score.ToString();
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

    private void OnDestroy()
    {
        instance = null;
    }
}
