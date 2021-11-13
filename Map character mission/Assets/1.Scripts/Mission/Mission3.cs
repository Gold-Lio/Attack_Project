using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Mission3 : MonoBehaviour
{

    Animator anim;
    PlayerCtrl playerCtrl_script;
    public Transform Numbers;
    int count;
    public Color blue;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        


        //숫자랜덤 배치
        for (int i = 0; i < 10; i++)
        {
            Sprite temp = Numbers.GetChild(i).GetComponent<Image>().sprite;
            int rand = Random.Range(0, 10);
            Numbers.GetChild(i).GetComponent<Image>().sprite = Numbers.GetChild(rand).GetComponent<Image>().sprite;
            Numbers.GetChild(rand).GetComponent<Image>().sprite = temp;

        }

    }

    //미션시작
    public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();

        //버튼초기화
        for (int i = 0; i < Numbers.childCount; i++)
        {
            Numbers.GetChild(i).GetComponent<Image>().color = Color.white;
        }

        count = 1;
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
        if (count.ToString() == EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name)
        {
            //색변경
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = blue;
            count++;

            //성공여부 체크
            if (count == 11)
            {
                Invoke("MissionSuccess", 0.5f);
            }
        }
    }

    //미션성공하면 호출
    public void MissionSuccess()
    {
        ClickCancle();
    }
}
