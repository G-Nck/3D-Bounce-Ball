using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPoint : MonoBehaviour
{
    //클리어 포인트 또한 맵 프리팹에 속하기 때문에,
    //클리어 이후 맵이 리셋될 경우 isTriggered가 false 인 클리어 포인트가 존재합니다.
    private bool isTriggered = false;

    void Start()
    {
 
        GameManager.Instance.onGameCleared += GameClear;
    }



    void GameClear()
    {
        Debug.Log("게임 클리어됨");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered) return;
        isTriggered = true;
        GameManager.Instance.onGameCleared.Invoke();
        this.enabled = false;
    }


}
