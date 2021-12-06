using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableBlock : Block
{
    [SerializeField]
    MMFeedbacks mMFeedbacks;


    [Tooltip("플레이어 충돌이 감지되었을 때만 이벤트를 실행할지")]
    [SerializeField]
    bool detectOnlyPlayer = false;

    override protected void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    override protected void OnCollisionEnter(Collision collision)
    {
       
        if (detectOnlyPlayer)
            if (!collision.gameObject.CompareTag("Player")) return;
        mMFeedbacks.PlayFeedbacks();
    }

   
    public void BlockFalling()
    {
        mMFeedbacks.Feedbacks[0].Active = false;
        _rigidbody.isKinematic = false;
        
    }
}
