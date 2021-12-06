using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayGameInfo : MonoBehaviour
{
    [SerializeField] TMP_Text versionText;

    private void Awake()
    {
        versionText.text = "Version "+Application.version;
    }

}
