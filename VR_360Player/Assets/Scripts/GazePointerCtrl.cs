using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

//ī�޶��� �ü��� ó���ϱ� ���� ���
public class GazePointerCtrl : MonoBehaviour
{
    public Transform uiCanvas; //���� �ð� ���� �ü��� �ӹ����� ���� �����ֱ� ���� UI
    public Image gazeImg; //�ü��� �ӹ��� ���� ��ȭ�� ǥ���ϱ� ���� UI image ������Ʈ

    Vector3 defaultScale; //UI �⺻ �������� �����صα� ���� ��
    public float uiScaleVal = 1f; //UIī�޶� 1m �� �� ����
    void Start()
    {
        defaultScale = uiCanvas.localScale; //������Ʈ�� ���� �⺻ ������ ��
    }

    void Update()
    {
        //ĵ���� ������Ʈ�� �������� �Ÿ��� ���� ����
        //1.ī�޶� �������� ���� ������ ��ǥ�� ���Ѵ�
        Vector3 dir = transform.TransformPoint(Vector3.forward);
        //2.ī�޶� �������� ������ ������ �����Ѵ�
        Ray ray = new Ray(transform.position, dir);
        RaycastHit hitInfo; //��Ʈ�� ������Ʈ�� ������ ��´�
        //3.���̿� �ε��� ��쿡�� �Ÿ����� �̿��� uiCanvas�� ũ�⸦ �����Ѵ�
        if(Physics.Raycast(ray, out hitInfo))
        {
            uiCanvas.localScale = defaultScale * uiScaleVal * hitInfo.distance;
            uiCanvas.position = transform.forward * hitInfo.distance;
        }
        else //4.�ƹ��͵� �ε����� ������ �⺻ ������ ������ uiCanvas�� ũ�⸦ �����Ѵ�
        {
            uiCanvas.localScale = defaultScale * uiScaleVal;
            uiCanvas.position = transform.position + dir;
        }
        //5.uiCanvas�� �׻� ī�޶� ������Ʈ�� �ٶ󺸰� �Ѵ�
        uiCanvas.forward = transform.forward * -1;
    }
}
