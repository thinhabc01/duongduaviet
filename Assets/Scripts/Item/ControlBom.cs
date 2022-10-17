using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBom : MonoBehaviour
{
    private Rigidbody2D Rg;
    private Animator An;
    // Start is called before the first frame update
    void Start(){
        An = GetComponent<Animator>();
        Rg = GetComponent<Rigidbody2D>();
        StartCoroutine (delay1 ());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag.Equals("play1")||other.gameObject.tag.Equals("play2")||other.gameObject.tag.Equals("play3")||other.gameObject.tag.Equals("play4")){
            An.SetBool("no", true);
            Rg.constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine (delay ());

        }
    }
    IEnumerator delay(){
        yield return new WaitForSeconds (0.5f);
        Destroy(gameObject);
    }
    IEnumerator delay1(){
        yield return new WaitForSeconds (5);
        An.SetBool("no", true);
        Rg.constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine (delay ());
    }
}
