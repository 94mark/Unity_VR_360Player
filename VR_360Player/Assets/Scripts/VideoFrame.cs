using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; //VideoPlayer ����� ����ϱ� ���� ���ӽ����̽�

public class VideoFrame : MonoBehaviour
{
    //Video Player ������Ʈ
    VideoPlayer vp;
    
    void Start()
    {
        //���� ������Ʈ�� ���� �÷��̾� ������Ʈ ������ ������ �´�
        vp = GetComponent<VideoPlayer>();
        //�ڵ� ����Ǵ� ���� ���´�
        vp.Stop();
    }

    void Update()
    {
        //S�� ������ ����
        if(Input.GetKeyDown(KeyCode.S))
        {
            vp.Stop();
        }
        //�����̽� �ٸ� ������ �� ��� �Ǵ� �Ͻ� ����
        if(Input.GetKeyDown("space"))
        {
            //���� ���� �÷��̾ �÷��� �������� Ȯ��
            if(vp.isPlaying)
            {
                //��� ���̶�� �Ͻ� ����
                vp.Pause();
            }
            else
            {
                //�׷��� �ʴٸ� �÷���
                vp.Play();
            }
        }
    }

    //GazePointerCtril���� ���� ����� ��Ʈ���ϱ� ���� �Լ�
    public void CheckVideoFrame(bool Checker)
    {
        if(Checker)
        {
            if(!vp.isPlaying)
            {
                vp.Play();
            }
        }
        else
        {
            vp.Stop();
        }
    }
}
