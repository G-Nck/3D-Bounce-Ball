using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// ���� Ŭ���� �� Ȱ��ȭ�� UI Panel
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
