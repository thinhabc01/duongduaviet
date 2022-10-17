using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RControl : MonoBehaviour
{
    private float time = 2.7f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (delay ());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        Vector3 Vspeed = new Vector3(0, -1, 0);
        transform.position = temp + Vspeed*Time.deltaTime;
    }
    IEnumerator delay(){
        yield return new WaitForSeconds (time);
        transform.position = new Vector3(transform.position.x, -1, 0);
        StartCoroutine (delay ());
    }
}
