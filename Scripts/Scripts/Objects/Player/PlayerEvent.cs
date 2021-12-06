using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvent : MonoBehaviour
{
    /// <summary>
    /// «√∑π¿ÃæÓ ªÁ∏¡ ¿Ã∆Â∆Æ
    /// </summary>
    [SerializeField] MMFeedbacks DeadFeedbacks;


    public void Dead()
    {
        GameManager.Instance.onPlayerDie.Invoke();
        DeadFeedbacks.PlayFeedbacks();
        Destroy(gameObject);
    }
}
