using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangGo : MonoBehaviour
{
    public Transform handle, rotate;
    Animator anim;
    PlayerCtrl playerCtrl_script;
    RectTransform rect_handle;



    bool isDrag;
     
   
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rect_handle = handle.GetComponent<RectTransform>();

    }
    public void Update()
    {
       

        //드래그
        if (isDrag)
        {
            handle.position = Input.mousePosition;
            rect_handle.anchoredPosition = new Vector2(184, Mathf.Clamp(rect_handle.anchoredPosition.y, -222, 222));

            //드래그 끝남
            if (Input.GetMouseButtonUp(0))
            {
                //성공여부 체크
                if(rect_handle.anchoredPosition.y > -3 && rect_handle.anchoredPosition.y < 3)
                {
                    Invoke("MissionSuccess", 2);
                }
                isDrag = false;

                

            }
        }
        rotate.eulerAngles = new Vector3(0, 0, 90*rect_handle.anchoredPosition.y /222);

        //색변경
      
        if (rect_handle.anchoredPosition.y > -3 && rect_handle.anchoredPosition.y < 3)
        {
            Invoke("MissionSuccess", 2);
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
    //핸들 누르면 호출
    public void ClickHandle()
    {
        isDrag = true;
    }
    
    
    //미션성공하면 호출
    public void MissionSuccess()
    {
        ClickCancle();
    }
}
