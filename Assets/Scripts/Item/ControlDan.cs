using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDan : MonoBehaviour
{
    public float speed;
    [SerializeField] private GameObject KhoiXe;
    private GameObject _KhoiXe;
    private Animator An;
    // Start is called before the first frame update
    void Start(){
        An = GetComponent<Animator>();
        KhoiXe.GetComponent<ControlKhoi>().Player = gameObject;
        _KhoiXe = Instantiate (KhoiXe, transform.position, Quaternion.identity);
        _KhoiXe.GetComponent<Animator>().SetBool("tangtoc", true);
        StartCoroutine (delay1 ());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        Vector3 Vspeed = new Vector3(speed, 0, 0);
        transform.position = temp + Vspeed*Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag.Equals("ground")){
            speed = 0;
            An.SetBool("no", true);
            StartCoroutine (delay ());
        }
        if (other.gameObject.tag.Equals("play1")||other.gameObject.tag.Equals("play2")||other.gameObject.tag.Equals("play3")||other.gameObject.tag.Equals("play4")){
            An.SetBool("no", true);
            speed = 0;
            StartCoroutine (delay ());

        }
    }
    IEnumerator delay(){
        yield return new WaitForSeconds (0.5f);
        Destroy(_KhoiXe);
        Destroy(gameObject);
    }
    IEnumerator delay1(){
        yield return new WaitForSeconds (10);
        An.SetBool("no", true);
        StartCoroutine (delay ());
    }
}
