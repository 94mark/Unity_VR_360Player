using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ٶ󺸴� ������ �Ʒ��� ���ϸ� �޴��� Ȱ��ȭ�Ѵ�
public class MenuSwitch : MonoBehaviour
{
    public GameObject videoFrameMenu;
    public float dot;
    //public float minAngle = 65; //�޴��� �����ֱ� ���� �ּ� ����
    //public float maxAngle = 90; //�޴��� �����ֱ� ���� �ִ� ����

    void Update()
    {
        /*if(transform.eulerAngles.x >= minAngle && transform.eulerAngles.x < maxAngle)
        {
            videoFrameMenu.SetActive(true); //�޴� Ȱ��ȭ
        }
        else
        {
            videoFrameMenu.SetActive(false); //�޴� ��Ȱ��ȭ
        }*/

        //������ ���� ���� ��
        dot = Vector3.Dot(transform.forward, Vector3.up);
        if(dot < -0.5)
        {
            videoFrameMenu.SetActive(true); //�޴� Ȱ��ȭ
        }
        else
        {
            videoFrameMenu.SetActive)(false); //�޴� ��Ȱ��ȭ
        }
    }
}
