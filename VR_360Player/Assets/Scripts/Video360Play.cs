using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video360Play : MonoBehaviour
{
    //비디오 플레이어 컴포넌트
    VideoPlayer vp;
    //재생해야 할 VR 360 영상을 위한 설정
    public VideoClip[] vcList; //다수의 비디오 클립을 배열로 만들어 관리
    int curVCidx; //현재 재생중인 클립 번호 저장
    void Start()
    {
        //비디오 플레이어 컴포넌트 정보를 받아온다
        vp = GetComponent<VideoPlayer>();
        vp.clip = vcList[0];
        curVCidx = 0;
        vp.Stop();
    }

    void Update()
    {
        //컴퓨터에서 영상을 변경하기 위한 기능
        if(Input.GetKeyDown(KeyCode.LeftBracket)) //왼쪽 대괄호 입력 시 이전 영상
        {
            vp.clip = vcList[0];
        }
        else if(Input.GetKeyDown(KeyCode.RightBracket))  //오른쪽 대괄호 입력 시 이전 영상
        {
            vp.clip = vcList[1];
        }
    }
}
