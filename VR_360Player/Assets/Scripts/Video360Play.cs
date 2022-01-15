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
            SwapVideoClip(false);
        }
        else if(Input.GetKeyDown(KeyCode.RightBracket))  //������ ���ȣ �Է� �� ���� ����
        {
            SwapVideoClip(true);
        }
    }
    //���ͷ����� ���� �Լ��� �ۺ����� ����
    //�迭�� �ε��� ��ȣ�� �������� ������ ��ü, ����ϱ� ���� �Լ�
    //���� ���� isNext�� true�̸� ���� ����, false�� ���� ���� ���
    public void SwapVideoClip(bool isNext)
    {
        //���� ��� ���� ������ �ѹ��� �������� üũ
        //���� ���� ��ȣ�� ���� ���󺸴� �迭���� �ε��� ��ȣ�� 1 �۴�
        //���� ���� ��ȣ�� ���� ���󺸴� �迭���� �ε��� ��ȣ�� 1 ũ��
        int setVCnum = curVCidx; //���� ��� ���� ������ �ѹ��� �Է��Ѵ�
        vp.Stop(); //���� ��� ���� ���� Ŭ���� �����Ѵ�
        //����� ������ ���� ���� ����
        if(isNext) //isNext ������ ���̶�� ����Ʈ�� ���� ���� ���
        {
            //����Ʈ ��ü ���̺��� ũ�� Ŭ���� ����Ʈ�� ù ��° �������� ����
            setVCnum = ((setVCnum + 1) % vcList.Length);
        }
        else
        {
            //�迭�� ���� ������ ���
            setVCnum = ((setVCnum - 1) + vcList.Length) % vcList.Length;
        }
        vp.clip = vcList[setVCnum]; //Ŭ���� ����
        vp.Play(); //�ٲ� Ŭ���� ���
        curVCidx = setVCnum; //�ٲ� Ŭ���� ���� ��ȣ�� ������Ʈ
    }
}
