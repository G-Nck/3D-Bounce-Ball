using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// 게임 클리어 시 활성화될 UI Panel
    /// </summary>
    [SerializeField]
    GameObject clearPanel;


    
    void Start()
    {
        GameManager.Instance.onGameCleared += DisplayClearWindow;
    }

    void DisplayClearWindow()
    {
        clearPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
