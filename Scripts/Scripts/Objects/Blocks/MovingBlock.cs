using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{

    Vector3 startPosition;
    Vector3 targetPosition;

    [SerializeField]
    Vector3 moveOffset;

    [SerializeField]
    float timerOffset;


    [SerializeField]
    Vector3 dir;

    [SerializeField]
    bool randomMoveOffset;
    [SerializeField]
    bool randomTimerOffset;
    [SerializeField]
    Vector2 randomRange;
    [SerializeField]
    float speed;
    [SerializeField]
    bool randomSpeed;

    [SerializeField]
    bool randomDirection;

    Rigidbody m_rigidbody;

    private void Start()
    {
       m_rigidbody = GetComponent<Rigidbody>();
        timer += timerOffset;
        if (randomTimerOffset) timer += Random.Range(0f, 5f);
        
        startPosition = transform.position;
        
        float minRange = randomRange.x;
        float maxRange = randomRange.y;
        if (randomDirection)
        {
            var value = Random.Range(0f, 100f);
            if (value >= 50f) dir = new Vector3(1, 0, 1); 
            else dir = new Vector3(0, 1, 0);
        }

        

        if (randomMoveOffset)
        {
            moveOffset = new Vector3(Random.Range(minRange, maxRange) * dir.x, Random.Range(minRange, maxRange) * dir.y, Random.Range(minRange, maxRange) * dir.z);

        }
           
        
        targetPosition = startPosition + moveOffset;
        speed = randomSpeed ? Random.Range(0.5f, 3f) : speed;
    }


    float timer;
    // Update is called once per frame

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        //m_rigidbody.MovePosition(Vector3.Lerp(startPosition, targetPosition, (Mathf.Sin(timer * speed) + 1) / 2));
        transform.position = Vector3.Lerp(startPosition, targetPosition, (Mathf.Sin(timer * speed) + 1) / 2);
    }

    void Update()
    {
       // transform.position = Vector3.Lerp(startPosition, targetPosition, (Mathf.Sin(timer * speed) + 1) / 2);

    }
}
