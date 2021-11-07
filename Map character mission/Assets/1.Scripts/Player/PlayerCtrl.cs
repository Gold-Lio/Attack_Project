using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject joyStick, mainView, missionView;
    public Button btn;

    Animator anim;
    GameObject coll;
    public float speed;

    bool isCantMove;

    public bool isJoyStick;
    private void Start()
    {
        anim = GetComponent<Animator>();
        Camera.main.transform.parent = transform;
        Camera.main.transform.localPosition = new Vector3(0, 0, -10);
    }
    private void FixedUpdate()
    {
        if (isCantMove)
        {
            joyStick.SetActive(false);
        }
        else
        {
            Move();
        }
    }

    //ĳ���Ϳ�����
    void Move()
    {
        if (isJoyStick)
        {
            joyStick.SetActive(true);
        }
        else
        {
            joyStick.SetActive(false);

            //Ŭ���ߴ��� �Ǵ�
            if (Input.GetMouseButton(0))
            {
                Vector3 dir = (Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f)).normalized;

                transform.position += dir * speed * Time.deltaTime;

                anim.SetBool("isWalk", true);




                //���� �̵�
                if (dir.x < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                //������ �̵�
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
            else
            {
                anim.SetBool("isWalk", false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Mission")
        {
            coll = collision.gameObject;
            btn.interactable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Mission")
        {
            coll = null;
            btn.interactable = false;
        }
    }
    //use��ư ������ �̼� ȣ��
    public void ClickButton()
    {
        //MissionStart�� ȣ��
        coll.SendMessage("MissionStart");

        isCantMove = true;
        btn.interactable = false;
    }
    //�̼� �����ϸ� ȫ��
    public void MissionEnd()
    {
        isCantMove = false;

    }
}
