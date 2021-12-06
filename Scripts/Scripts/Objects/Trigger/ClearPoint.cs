using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPoint : MonoBehaviour
{
    //Ŭ���� ����Ʈ ���� �� �����տ� ���ϱ� ������,
    //Ŭ���� ���� ���� ���µ� ��� isTriggered�� false �� Ŭ���� ����Ʈ�� �����մϴ�.
    private bool isTriggered = false;

    void Start()
    {
 
        GameManager.Instance.onGameCleared += GameClear;
    }



    void GameClear()
    {
        Debug.Log("���� Ŭ�����");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered) return;
        isTriggered = true;
        GameManager.Instance.onGameCleared.Invoke();
        this.enabled = false;
    }


}
