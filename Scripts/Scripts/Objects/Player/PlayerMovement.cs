using Cinemachine;
using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1f;

    [SerializeField]
    [Range(0f, 50f)]
    float jumpDistance = 5f;

    Rigidbody rig;

    BoxCollider boxCol;

    Vector3 dir;

    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    bool onGround;

    RaycastHit info;
    [SerializeField]
    MMFeedbacks bounceFeedbacks;


    CinemachineFreeLook vCam;

    private void Awake()
    {
        boxCol = GetComponent<BoxCollider>();
        rig = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
     
    }

    private void FixedUpdate()
    {
        onGround = Physics.BoxCast(transform.position, new Vector3(1,0.1f,1) / 2, Vector3.down, out info, transform.rotation, 5f, layerMask);
        Debug.DrawRay(transform.position , Vector3.down, Color.red);
        if(dir.magnitude > 0)
        {
            transform.Translate(Time.fixedDeltaTime * moveSpeed * moveDir.normalized, Space.World);

        } 
    }

    Vector3 moveDir;

    float velocity;
    // Update is called once per frame
    void Update()
    {
        float targetAngle, angle;
        dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0 , Input.GetAxisRaw("Vertical")).normalized;
        if(dir.magnitude > 0)
        {
            targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref velocity, 0);

            transform.rotation = Quaternion.Euler(0, angle, 0);
            moveDir = Quaternion.Euler(0, angle, 0) * Vector3.forward;
        }

     
        



        if (Input.GetAxisRaw("Jump") == 1)
            Jump();


        if (transform.position.y < -15f)
            gameObject.GetComponent<PlayerEvent>().Dead();

    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("meow");
        Jump();
    }

    void Jump()
    {
        if (onGround && Mathf.Approximately(0, rig.velocity.y))
        {          
            onGround = false;
            bounceFeedbacks.PlayFeedbacks();
            rig.AddForce(Vector3.up * jumpDistance, ForceMode.VelocityChange);
            Debug.Log(info.collider.gameObject.name + "distance:" + info.distance + "velocity" + rig.velocity.y);
        }
    }



    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("meow");
        Jump();
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("meow");
    }
}
