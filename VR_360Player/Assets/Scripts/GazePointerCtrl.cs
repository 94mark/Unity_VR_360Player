using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

//ī�޶��� �ü��� ó���ϱ� ���� ���
public class GazePointerCtrl : MonoBehaviour
{
    public Video360Play vp360; //360 ���Ǿ �߰��� ���� �÷��� ���
    public Transform uiCanvas; //���� �ð� ���� �ü��� �ӹ����� ���� �����ֱ� ���� UI
    public Image gazeImg; //�ü��� �ӹ��� ���� ��ȭ�� ǥ���ϱ� ���� UI image ������Ʈ

    Vector3 defaultScale; //UI �⺻ �������� �����صα� ���� ��
    public float uiScaleVal = 1f; //UIī�޶� 1m �� �� ����

    bool isHitObj; //���ͷ����� �Ͼ�� ������Ʈ�� �ü��� ������ true, ���� ������ false
    GameObject prevHitObj; //���� �������� �ü��� �ӹ����� ������Ʈ ������ ��� ���� ����
    GameObject curHitObj; //���� �������� �ü��� �ӹ����� ������Ʈ ������ ��� ���� ����
    float curGazeTime = 0; //�ü��� �ӹ����� �ð��� �����ϱ� ���� ����
    public float gazeChargeTime = 3f; //�ü��� �ӹ� �ð��� üũ�ϱ� ���� ���� �ð� 3��(�ʿ信 ���� ����)

    void Start()
    {
        defaultScale = uiCanvas.localScale; //������Ʈ�� ���� �⺻ ������ ��
        curGazeTime = 0; //�ü��� �����ϴ��� üũ�ϱ� ���� ���� �ʱ�ȭ
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
            if(hitInfo.transform.tag == "GazeObj")
            {
                isHitObj = true;
            }
            curHitObj = hitInfo.transform.gameObject;
        }
        else //4.�ƹ��͵� �ε����� ������ �⺻ ������ ������ uiCanvas�� ũ�⸦ �����Ѵ�
        {
            uiCanvas.localScale = defaultScale * uiScaleVal;
            uiCanvas.position = transform.position + dir;
        }
        //5.uiCanvas�� �׻� ī�޶� ������Ʈ�� �ٶ󺸰� �Ѵ�
        uiCanvas.forward = transform.forward * -1;

        //GazeObj�� ���̰� ����� �� ����
        if(isHitObj)
        {
            if(curHitObj == prevHitObj) //���� �����Ӱ� ���� �������� ������Ʈ�� ���ƾ� �ð� ����
            {
                //���ͷ����� �߻��ؾ� �ϴ� ������Ʈ�� �ü��� ������ �ִٸ� �ð� ����
                curGazeTime += Time.deltaTime;
            }
            else
            {
                //���� �������� ���� ������ ������Ʈ�Ѵ�
                prevHitObj = curHitObj;
            }
            //hit�� ������Ʈ�� VideoPlayer ������Ʈ�� ���� �ִ��� Ȯ���Ѵ�
            HitObjChecker(curHitObj, true);
        }
        else //�ü��� ����ų� GazeObj�� �ƴ϶�� �ð��� �ʱ�ȭ
        {
            if(prevHitObj != null)
            {
                HitObjChecker(prevHitObj, false);
                prevHitObj = null;
            }
            curGazeTime = 0;
        }
        //�ü��� �ӹ� �ð��� 0�� �Ҵ� ���̷� �Ѵ�
        curGazeTime = Mathf.Clamp(curGazeTime, 0, gazeChargeTime);
        //ui image�� fillAmount�� ������Ʈ�Ѵ�
        gazeImg.fillAmount = curGazeTime / gazeChargeTime;

        isHitObj = false; //��� ó���� ������ isHitObj�� false�� �Ѵ�
        curHitObj = null; //curHitObj ������ �����
    }
    //��Ʈ�� ������Ʈ Ÿ�Ժ��� �۵� ����� �����Ѵ�
    void HitObjChecker(GameObject hitObj, bool isActive)
    {
        //hit�� ���� �÷��̾� ������Ʈ�� ���� �ִ��� Ȯ���Ѵ�
        if(hitObj.GetComponent<VideoPlayer>())
        {
            if(isActive)
            {
                hitObj.GetComponent<VideoFrame>().CheckVideoFrame(true);
            }
            else
            {
                hitObj.GetComponent<VideoFrame>().CheckVideoFrame(false);
            }
        }
        //������ �ð��� �Ǹ� 360 ���Ǿ Ư�� Ŭ�� ��ȣ�� ������ �÷����Ѵ�
        if (gazeImg.fillAmount >= 1)
        {
            //���� �÷��̾ ���� Mesh_Collider ������Ʈ�� �̸��� ���� ����/���� �������� ���
            if (hitObj.name.Contains("Right"))
            {
                vp360.SwpVideoClip(true); //���� ����
            }
            else if (hitObj.name.Contains("Left"))
            {
                vp360.SwpVideoClip(false); //���� ����
            }
            else
            {
                //360 ���Ǿ Ư�� Ŭ�� ��ȣ�� ������ �÷���
                vp360.SetVideoPlay(hitObj.transform.GetSiblingIndex());
            }
            curGazeTime = 0; //���� �ð��� �ʱ�ȭ�� �ڵ尡 �ݺ��ؼ� �Ҹ��� ���� ����
        }
}
