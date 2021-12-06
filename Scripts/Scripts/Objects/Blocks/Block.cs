using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    protected Rigidbody _rigidbody;
    protected Collider _collider;

    virtual protected void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual protected void OnTriggerEnter(Collider other)
    {
        
    }


    virtual protected void OnCollisionEnter(Collision collision)
    {
        
    }

}
