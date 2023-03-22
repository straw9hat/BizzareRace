using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lapCounter : MonoBehaviour
{
    public static int lapNum;
    // Start is called before the first frame update
    void Start()
    {
        lapNum = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(1);
        if (other.gameObject.name == "Car" || other.gameObject.name == "Car(Clone)")
        {
            Debug.Log(2);
            lapNum++;
            this.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(LapCouroutine());
        }
    }
    IEnumerator LapCouroutine()
    {
        yield return new WaitForSeconds(30);
        this.GetComponent<BoxCollider>().enabled = true;
    }
}