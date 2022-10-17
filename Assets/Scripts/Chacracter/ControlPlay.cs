using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlay : MonoBehaviour
{
    public bool isPlayer = false;
    [SerializeField] private GameObject KhoiXe;
    private GameObject _KhoiXe;
    // Start is called before the first frame update
    void Start()
    {
        KhoiXe.GetComponent<ControlKhoi>().Player = gameObject;
        _KhoiXe = Instantiate (KhoiXe, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x == 1){
            _KhoiXe.GetComponent<ControlKhoi>().temp =new Vector3(-1, 0.1f, 0);
            _KhoiXe.GetComponent<Transform>().localScale = new Vector3(1,1,0);
        }
        else{
            _KhoiXe.GetComponent<ControlKhoi>().temp =new Vector3(1, 0.1f, 0);
            _KhoiXe.GetComponent<Transform>().localScale = new Vector3(-1,1,0);
        }
        if(GetComponent<PlayMove>().isTangtoc){
            _KhoiXe.GetComponent<Animator>().SetBool("tangtoc", true);
        } 
        else{
            _KhoiXe.GetComponent<Animator>().SetBool("tangtoc", false);
            //_KhoiXe.GetComponent<ControlKhoi>().moveSpeed-=10;
        }
    }
}
