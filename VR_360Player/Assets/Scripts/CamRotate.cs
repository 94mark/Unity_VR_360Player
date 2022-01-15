using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//마우스 입력에 따라 카메라를 회전시킨다
//필요 속성 : 현재 각도, 마우스 각도
public class CamRotate : MonoBehaviour
{
    //현재 각도
    Vector3 angle;
    //마우스 감도
    public float sensitivity = 200;

    void Start()
    {
        //시작할 때 현재 카메라의 각도를 적용
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
