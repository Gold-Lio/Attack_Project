using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Mission1 : MonoBehaviour
{
    public Color black,white;
    public Image[] images;
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

        //버튼 랜덤생성 작업
        for(int i = 0; i < 0; i++)
        {
            int rand = Random.Range(0, 9);
            images[rand].color = black;
        }
    }
    //엑스버튼 누르면 호출
    public void ClickCancle()
    {
        anim.SetBool("isUp", false);
        playerCtrl_script.MissionEnd();
    }
    //원 버튼 누르면 호출
    public void ClickButton()
    {
       Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();

        //하얀색
        if (img.color == Color.white)
        {
            img.color = white;
        }
        else
        {
            img.color = Color.white;
        }

        //성공여부 체크
        int count = 0;
        for (int i = 0; i < images.Length; i++)
        {
            if(images[i].color == Color.clear)
            {
                count++;
            }
        }
        if(count == images.Length)
        {
            //성공
            Invoke("MissionSuccess", 0.5f);
        }
    }
    //미션성공하면 호출
    public void MissionSuccess()
    {
        ClickCancle();
    }
}
