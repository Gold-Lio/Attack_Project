using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Mission2 : MonoBehaviour
{
    public Text inputText, KeyCode;

    Animator anim;
    PlayerCtrl playerCtrl_script;
    
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        //키코드 랜덤생성
        for (int i = 0; i < 2; i++)
        {

            KeyCode.text += Random.Range(0, 9);

        }


    }

    //미션시작
    public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();

        
        

    }
    //엑스버튼 누르면 호출
    public void ClickCancle()
    {
        anim.SetBool("isUp", false);
        playerCtrl_script.MissionEnd();
    }
    //숫자버튼 누르면 호출
    public void ClickNumber()
    {
        if (inputText.text.Length <= 1)
        {
            inputText.text += EventSystem.current.currentSelectedGameObject.name;
        }
        
    }
    //삭제버튼 누르면 호출
    public void ClickDelete()
    {
        if(inputText.text != "")
        {
            inputText.text = inputText.text.Substring(0, inputText.text.Length - 1);
        }
    }
    //체크버튼 누르면 호출
    public void ClickCheck()
    {
        if(inputText.text == KeyCode.text)
        {
            MissionSuccess();
        }
    }

    //미션성공하면 호출
    public void MissionSuccess()
    {
        ClickCancle();
    }
}
