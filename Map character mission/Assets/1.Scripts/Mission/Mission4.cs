using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Mission4 : MonoBehaviour
{


    public Transform Arrow;

    Animator anim;
    PlayerCtrl playerCtrl_script;
    RectTransform rect_Arrow;

    bool isDrag;
    Vector2 originPos;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rect_Arrow = Arrow.GetComponent<RectTransform>();
        Vector2 originPos = rect_Arrow.anchoredPosition;

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
    //화살표 누르면 호출
    public void ClickArrow()
    {
        isDrag = true;

        //드래그
        if (isDrag)
        {
            Arrow.position = Input.mousePosition;
            rect_Arrow.anchoredPosition = new Vector2(Mathf.Clamp(rect_Arrow.anchoredPosition.x, -4.2f, 190), originPos.y);

            //드래그 끝남
            if (Input.GetMouseButtonUp(0))
            {
                //rect_Arrow.anchoredPosition = originPos;
                isDrag = false;
            }
        }

        //성공여부 체크
        if (rect_Arrow.anchoredPosition.x == 190)
        {
            Invoke("MissionSuccess", 0.5f);
        }
    }



    //미션성공하면 호출
    public void MissionSuccess()
    {
        ClickCancle();
    }
}
