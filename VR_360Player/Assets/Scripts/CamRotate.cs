using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���콺 �Է¿� ���� ī�޶� ȸ����Ų��
//�ʿ� �Ӽ� : ���� ����, ���콺 ����
public class CamRotate : MonoBehaviour
{
    //���� ����
    Vector3 angle;
    //���콺 ����
    public float sensitivity = 200;

    void Start()
    {
        //������ �� ���� ī�޶��� ������ ����
        angle.y = -Camera.main.transform.eulerAngles.x;
        angle.x = Camera.main.transform.eulerAngles.y;
        angle.z = Camera.main.transform.eulerAngles.z;
    }

    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        angle.x += x * sensitivity * Time.deltaTime;
        angle.y += y * sensitivity * Time.deltaTime;

        transform.eulerAngles = new Vector3(-angle.y, angle.x, angle.z);
    }
}
