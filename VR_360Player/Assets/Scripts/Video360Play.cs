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
            SwapVideoClip(false);
        }
        else if(Input.GetKeyDown(KeyCode.RightBracket))  //오른쪽 대괄호 입력 시 이전 영상
        {
            SwapVideoClip(true);
        }
    }
    //인터랙션을 위해 함수를 퍼블릭으로 서언
    //배열의 인덱스 번호를 기준으로 영상을 교체, 재생하기 위한 함수
    //인자 값인 isNext가 true이면 다음 영상, false면 이전 영상 재생
    public void SwapVideoClip(bool isNext)
    {
        //현재 재생 중인 영상의 넘버를 기준으로 체크
        //이전 영상 번호는 현재 영상보다 배열에서 인덱스 번호가 1 작다
        //다음 영상 번호는 현재 영상보다 배열에서 인덱스 번호가 1 크다
        int setVCnum = curVCidx; //현재 재생 중인 영상의 넘버를 입력한다
        vp.Stop(); //현재 재생 중인 비디오 클립을 중지한다
        //재생될 영상을 고르기 위한 과정
        if(isNext) //isNext 변수가 참이라면 리스트의 다음 영상 재생
        {
            //리스트 전체 길이보다 크면 클립을 리스트의 첫 번째 영상으로 지정
            setVCnum = ((setVCnum + 1) % vcList.Length);
        }
        else
        {
            //배열의 이전 영상을 재생
            setVCnum = ((setVCnum - 1) + vcList.Length) % vcList.Length;
        }
        vp.clip = vcList[setVCnum]; //클립을 변경
        vp.Play(); //바뀐 클립을 재생
        curVCidx = setVCnum; //바뀐 클립의 영상 번호를 업데이트
    }
}
