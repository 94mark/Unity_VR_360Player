using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

//카메라의 시선을 처리하기 위한 기능
public class GazePointerCtrl : MonoBehaviour
{
    public Transform uiCanvas; //일정 시간 동안 시선이 머무르는 것을 보여주기 위한 UI
    public Image gazeImg; //시선이 머무는 동안 변화를 표현하기 위한 UI image 컴포넌트

    Vector3 defaultScale; //UI 기본 스케일을 저장해두기 위한 값
    public float uiScaleVal = 1f; //UI카메라가 1m 일 때 배율
    void Start()
    {
        defaultScale = uiCanvas.localScale; //오브젝트가 갖는 기본 스케일 값
    }

    void Update()
    {
        //캔버스 오브젝트의 스케일을 거리에 따라 조절
        //1.카메라를 기준으로 전방 방향의 좌표를 구한다
        Vector3 dir = transform.TransformPoint(Vector3.forward);
        //2.카메라를 기준으로 전방의 레이을 설정한다
        Ray ray = new Ray(transform.position, dir);
        RaycastHit hitInfo; //히트된 오브젝트의 정보를 담는다
        //3.레이에 부딪힌 경우에는 거리값을 이용해 uiCanvas의 크기를 조절한다
        if(Physics.Raycast(ray, out hitInfo))
        {
            uiCanvas.localScale = defaultScale * uiScaleVal * hitInfo.distance;
            uiCanvas.position = transform.forward * hitInfo.distance;
        }
        else //4.아무것도 부딪히지 않으면 기본 스케일 값으로 uiCanvas의 크기를 조절한다
        {
            uiCanvas.localScale = defaultScale * uiScaleVal;
            uiCanvas.position = transform.position + dir;
        }
        //5.uiCanvas가 항상 카메라 오브젝트를 바라보게 한다
        uiCanvas.forward = transform.forward * -1;
    }
}
