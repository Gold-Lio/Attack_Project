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

   //�̼ǽ���
   public void MissionStart()
    {
        anim.SetBool("isUp", true);
        playerCtrl_script = FindObjectOfType<PlayerCtrl>();

        //��ư �������� �۾�
        for(int i = 0; i < 0; i++)
        {
            int rand = Random.Range(0, 9);
            images[rand].color = black;
        }
    }
    //������ư ������ ȣ��
    public void ClickCancle()
    {
        anim.SetBool("isUp", false);
        playerCtrl_script.MissionEnd();
    }
    //�� ��ư ������ ȣ��
    public void ClickButton()
    {
       Image img = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();

        //�Ͼ��
        if (img.color == Color.white)
        {
            img.color = white;
        }
        else
        {
            img.color = Color.white;
        }

        //�������� üũ
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
            //����
            Invoke("MissionSuccess", 0.5f);
        }
    }
    //�̼Ǽ����ϸ� ȣ��
    public void MissionSuccess()
    {
        ClickCancle();
    }
}
