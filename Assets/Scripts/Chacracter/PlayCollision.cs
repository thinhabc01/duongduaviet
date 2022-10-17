using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCollision : MonoBehaviour
{
    private Rigidbody2D Rg;
    private Transform Tr;
    private Collider2D Cd;
    // Start is called before the first frame update
    void Start(){
        Rg = GetComponent<Rigidbody2D>();
        Tr = GetComponent<Transform>();
        Cd = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag.Equals("cho")){
            GetComponent<PlayMove>().jumppoint = true;
            GetComponent<PlayMove>().start = false;
            Vector3 temp1 = other.gameObject.transform.position;
            Vector3 temp2 = Tr.position;
            Rg.velocity = new Vector3((temp2.x-temp1.x)*6,0,0);
            StartCoroutine (delay ());
        }
    }
    void OnCollisionStay2D(Collision2D other){
        if (other.gameObject.tag.Equals("bom")){
            GetComponent<PlayMove>().start = false;
            Vector3 temp1 = other.gameObject.transform.position;
            Vector3 temp2 = Tr.position;
            Rg.velocity = (temp2-temp1)*12;
            StartCoroutine (delay ());
        }
    }
    void OnCollisionExit2D(Collision2D other){
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag.Equals("ga")){
            GetComponent<PlayMove>().start = false;
            Rg.velocity = new Vector2(-1,6);
            StartCoroutine (delay ());
        }
        if (other.gameObject.tag.Equals("voi")){
            GetComponent<PlayMove>().start = false;
            Rg.velocity = new Vector2(-1,15);
            StartCoroutine (delay ());
        }
        if (other.gameObject.tag.Equals("dan")){
            GetComponent<PlayMove>().start = false;
            Rg.velocity = new Vector2(-6,2);
            StartCoroutine (delay ());
        }
    }
    void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.tag.Equals("ga")){
            GetComponent<PlayMove>().start = false;
            Rg.velocity = new Vector2(-1,6);
            StartCoroutine (delay ());
        }
        if (other.gameObject.tag.Equals("voi")){
            GetComponent<PlayMove>().start = false;
            Rg.velocity = new Vector2(-1,15);
            StartCoroutine (delay ());
        }
        if (other.gameObject.tag.Equals("dan")){
            GetComponent<PlayMove>().start = false;
            Rg.velocity = new Vector2(-6,2);
            StartCoroutine (delay ());
        }
    }
    void OnTriggerExit2D(Collider2D other){
        
    }
    public IEnumerator delay(){
		yield return new WaitForSeconds (0.6f);
        GetComponent<PlayMove>().start = true;
	}
}
