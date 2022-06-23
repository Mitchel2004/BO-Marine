using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroomHit : MonoBehaviour
{
    public bool hit = false;
    private bool isOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightOn();
    }

    private void lightOn()
    {
        //if (gameObject.tag == puzzel.randomizedList[0])
        //{
            //isOn = true;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "vuist")
        {
            //animator.SetBool("mushroomHit", true);
            hit = true;
        }
    }
}
