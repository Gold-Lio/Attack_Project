using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WareHouse : MonoBehaviour
{

    Animator anim;
    PlayerCtrl playerCtrl_script;

    Vector2 ClickPos;
    LineRenderer line;

    bool isDrag;
    float topX, bottomX;
   
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        
    }
    public void Update()
    {
       

        //드래그
        if (isDrag)
        {
            line.SetPosition(1, new Vector3(Input.mousePosition.x - ClickPos.x, Input.mousePosition.y - ClickPos.y, -10));

            //드래그 끝남
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                //아래 선에 닿았다면
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject bottomLine = hit.transform.gameObject;

                    //아래 선 X값
                    bottomX = bottomLine.GetComponent<RectTransform>().anchoredPosition.x;

                    line.SetPosition(1, new Vector3(bottomX - topX, -500, -10));
                }
                //닿지 않았다면
                else
                {
                    line.SetPosition(1, new Vector3(0, 0, -10));
                }

                isDrag = false;
            }
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
    
    public void ClickLine(LineRenderer click)
    {
        ClickPos = Input.mousePosition;
        line = click;

        //위쪽 선 y값
        topX = click.transform.parent.GetComponent<RectTransform>().anchoredPosition.x;


        isDrag = true;
    }
    //미션성공하면 호출
    public void MissionSuccess()
    {
        ClickCancle();
    }
}
