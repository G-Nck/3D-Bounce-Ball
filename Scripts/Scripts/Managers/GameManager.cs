using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;



    [Tooltip("�÷��̾� ������ ������Ʈ")]
    [SerializeField] GameObject playerPrefab;

    [Tooltip("�÷��̾� ������ ��ġ")]
    [SerializeField] Transform spawnPoint;

    [SerializeField]
    CinemachineFreeLook vCamera;

    public UnityAction onPlayerDie;

    public UnityAction onGameCleared;

    [Tooltip("�÷��̾� ������ ������")]
    [SerializeField] float spawnDelay = 2f;


    [SerializeField]
    GameObject stagePrefab;
    GameObject stageInstance;






    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        SetStage();
        onPlayerDie += SpawnPlayer;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11)) SetFullScreen();
    }

    void SpawnPlayer()
    {
        StartCoroutine(Coroutine_SpawnPlayer());
    }


    void SetUpCamera(GameObject target)
    {
        vCamera.Follow = target.transform;
        vCamera.LookAt = target.transform;
       
    }

    IEnumerator Coroutine_SpawnPlayer()
    {

        yield return new WaitForSeconds(spawnDelay);
        ResetStage();
        SetUpCamera(Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation));
        yield break;
    }

    void SetStage()
    {
        stageInstance = Instantiate(stagePrefab, Vector3.zero, Quaternion.identity);
    }

    void ResetStage()
    {
        Destroy(stageInstance);
        SetStage();
    }

    public void RestartGame()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerEvent>().Dead();
    }


    void SetFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

}
