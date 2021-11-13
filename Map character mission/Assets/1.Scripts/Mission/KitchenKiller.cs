using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class KitchenKiller : MonoBehaviour
{


    private float clickTime; // 클릭 중인 시간
    public float minClickTime = 10f; // 최소 클릭시간
    private bool isClick; // 클릭 중인지 판단 

    public Text timeText;
    private float time;

    Animator anim;
    PlayerCtrl playerCtrl_script;
    

   
  
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
       

    }

    
    //미션시작
    public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();

        

}

    // 버튼 클릭이 시작했을 때
    public void ButtonDown()
    {
        isClick = true;
    }

    // 버튼 클릭이 끝났을 때
    public void ButtonUp()
    {
        isClick = false;
        

        // 클릭 중인 시간이 최소 클릭시간 이상이라면
        if (clickTime == minClickTime)
        {
            Invoke("MissionSuccess", 0.2f);
        }
    }

    private void Update()
    {
        // 클릭 중이라면
        if (isClick)
        {
            // 클릭시간 측정
            clickTime += Time.deltaTime;
            time += Time.deltaTime;
            timeText.text = Mathf.Ceil(time).ToString();
            if(timeText.text == "10")
            {
                MissionSuccess();
            }
            

        }

        // 클릭 중이 아니라면
        else
        {
            // 클릭시간 초기화
            clickTime = 0;
            //타이머 초기화
            //timeText.text = "";
            //time = 0f;

        }
    }

    //엑스버튼 누르면 호출
    public void ClickCancle()
    {
        anim.SetBool("isUp", false);
        playerCtrl_script.MissionEnd();
    }
    

    //미션성공하면 호출
    public void MissionSuccess()
    {
        ClickCancle();
        
    }
}
