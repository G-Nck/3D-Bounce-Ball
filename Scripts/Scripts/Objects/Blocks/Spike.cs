using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Block
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<PlayerEvent>().Dead();
    }
}
