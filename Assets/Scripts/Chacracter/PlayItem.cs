using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayItem : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private enum StateItem{Empty, Item1, Item2, Item3}
    [SerializeField] private StateItem PlayerStateItem;
    [SerializeField] private GameObject Dan;
    [SerializeField] private GameObject Bom;
    private Animator An;
    private GameObject iteminbag;
    // Start is called before the first frame update
    void Start()
    {
        iteminbag = GameObject.Find("ItemInBag");
        An = iteminbag.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ControlPlay>().isPlayer){
            if (Input.GetKey("space") && PlayerStateItem != StateItem.Empty){
                dotitem();
                PlayerStateItem = StateItem.Empty;
            }
            if (Input.GetKey(KeyCode.A)){PlayerStateItem = StateItem.Item1;}
            if (Input.GetKey(KeyCode.S)){PlayerStateItem = StateItem.Item2;}
            if (Input.GetKey(KeyCode.D)){PlayerStateItem = StateItem.Item3;}

            if (PlayerStateItem == StateItem.Item1){An.SetInteger("item", 1);}
            if (PlayerStateItem == StateItem.Item2){An.SetInteger("item", 2);}
            if (PlayerStateItem == StateItem.Item3){An.SetInteger("item", 3);}
            if (PlayerStateItem == StateItem.Empty){An.SetInteger("item", 0);}
        }
        else{
            if (PlayerStateItem == StateItem.Item3){
                dotitem();
                PlayerStateItem = StateItem.Empty;
            }
            if (PlayerStateItem == StateItem.Item2){
                Vector3 temp1 = Player.transform.position;
                Vector3 temp2 = transform.position;
                float f1 = temp1.x-temp2.x;
                float f2 = temp1.y-temp2.y;
                if(f1>3 && f1<7 && f2>-1 && f2<1){
                    dotitem();
                    PlayerStateItem = StateItem.Empty;
                }
            }
            if (PlayerStateItem == StateItem.Item1){
                Vector3 temp1 = Player.transform.position;
                Vector3 temp2 = transform.position;
                float f = temp1.x-temp2.x;
                if(f>-6 && f<-2){
                    dotitem();
                    PlayerStateItem = StateItem.Empty;
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag.Equals("item3")){
            if (PlayerStateItem == StateItem.Empty){
                PlayerStateItem = StateItem.Item3;
                other.gameObject.SetActive(false);
                StartCoroutine (TimeSkip (other.gameObject));
            }
        }
        if (other.gameObject.tag.Equals("item2")){
            if (PlayerStateItem == StateItem.Empty){
                PlayerStateItem = StateItem.Item2;
                other.gameObject.SetActive(false);
                StartCoroutine (TimeSkip (other.gameObject));
            }
        }
        if (other.gameObject.tag.Equals("item1")){
            if (PlayerStateItem == StateItem.Empty){
                PlayerStateItem = StateItem.Item1;
                other.gameObject.SetActive(false);
                StartCoroutine (TimeSkip (other.gameObject));
            }
        }
    }
    void dotitem(){
        if (PlayerStateItem == StateItem.Item3){
            StartCoroutine (GetComponent<PlayMove>().tangtoc() );
        }
        if (PlayerStateItem == StateItem.Item2){
            Vector3 temp = transform.position;
            Vector3 temp1 = new Vector3(GetComponent<Transform>().localScale.x, 0.5f,0);
            Dan.GetComponent<ControlDan>().speed = GetComponent<Transform>().localScale.x* 12;
            Dan.GetComponent<Transform>().localScale = new Vector3(GetComponent<Transform>().localScale.x,1,0);
            Instantiate (Dan, temp+temp1, Quaternion.identity);
        }
        if (PlayerStateItem == StateItem.Item1){
            Vector3 temp = transform.position;
            Vector3 temp1 = new Vector3(-1f, 0.5f,0);
            Instantiate (Bom, temp+temp1, Quaternion.identity);
        }
    }
    IEnumerator TimeSkip(GameObject other){
		yield return new WaitForSeconds (30);
        other.SetActive(true);
    }
}
