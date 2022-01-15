using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video360Play : MonoBehaviour
{
    //���� �÷��̾� ������Ʈ
    VideoPlayer vp;
    //����ؾ� �� VR 360 ������ ���� ����
    public VideoClip[] vcList; //�ټ��� ���� Ŭ���� �迭�� ����� ����
    int curVCidx; //���� ������� Ŭ�� ��ȣ ����
    void Start()
    {
        //���� �÷��̾� ������Ʈ ������ �޾ƿ´�
        vp = GetComponent<VideoPlayer>();
        vp.clip = vcList[0];
        curVCidx = 0;
        vp.Stop();
    }

    void Update()
    {
        //��ǻ�Ϳ��� ������ �����ϱ� ���� ���
        if(Input.GetKeyDown(KeyCode.LeftBracket)) //���� ���ȣ �Է� �� ���� ����
        {
            vp.clip = vcList[0];
        }
        else if(Input.GetKeyDown(KeyCode.RightBracket))  //������ ���ȣ �Է� �� ���� ����
        {
            vp.clip = vcList[1];
        }
    }
}
