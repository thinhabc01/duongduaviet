using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ControlSelect : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private Animator An;
    [SerializeField] private Button ButtonLeft;
    [SerializeField] private Button ButtonRight;
    [SerializeField] private Button ButtonPlay;
    [SerializeField] private Button ButtonBack;
    [SerializeField] private Text NamePlayer;
    [SerializeField] private Slider IndexTot;
    [SerializeField] private Slider IndexXau;
    [SerializeField] private Slider IndexLay;
    [SerializeField] private Slider IndexNuoc;
    [SerializeField] private Slider IndexNhay;
    
    private int HeightScreen;
    private int WidthScreen;
    private int p = 0;
    string[] Listname = new string[] { "Skipper", "Kowalski", "Rico", "Private"};
    float[,] Index = {{ 5.5f, 5f, 4f, 5.5f, 6.5f }, { 6f, 4f, 5f, 5f, 4.1f }, 
                      { 5f, 4f, 5f, 6f, 4.1f }, { 4f, 5f, 6f, 5f, 9f }};
    //Skipper, Kowalski, Rico, and Private
    // Start is called before the first frame update
    void Start()
    {
        // RectTransform b1 = ButtonLeft.GetComponent<RectTransform>();
        // RectTransform b2 = ButtonRight.GetComponent<RectTransform>();
        // RectTransform b3 = ButtonPlay.GetComponent<RectTransform>();
        // RectTransform b4 = ButtonBack.GetComponent<RectTransform>();
        ButtonPlay.onClick.AddListener(PlayOnClick);
        ButtonBack.onClick.AddListener(BackOnClick);
        ButtonLeft.onClick.AddListener(_ButtonLeft);
        ButtonRight.onClick.AddListener(_ButtonLRight);

        HeightScreen = Screen.height;
        WidthScreen = Screen.width;
        // int w = WidthScreen/3;
        // int h = HeightScreen/6;

        // b1.sizeDelta = new Vector2(w, HeightScreen*5/6);
        // b2.sizeDelta = new Vector2(w, HeightScreen*5/6);
        // b3.localScale = new Vector3(WidthScreen/1280f, HeightScreen/720f, 0f);
        // b4.localScale = new Vector3(WidthScreen/1280f, HeightScreen/720f, 0f);

        An = Player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(HeightScreen);
        // Debug.Log(WidthScreen);
    }
    public void _ButtonLeft(){
        if ( p == 0){
            p = 3;
        }
        else{
            p--;
        }
        An.SetInteger("Player", p);
        NamePlayer.text = Listname[p];
        // Debug.Log("Button Left");
        IndexTot.value = Index[p, 0]/9f;
        IndexXau.value = Index[p, 1]/9f;
        IndexLay.value = Index[p, 2]/9f;
        IndexNuoc.value = Index[p, 3]/9f;
        IndexNhay.value = Index[p, 4]/9f;
    }
    public void _ButtonLRight(){
        if ( p == 3){
            p = 0;
        }
        else{
            p++;
        }
        An.SetInteger("Player", p);
        NamePlayer.text = Listname[p];
        // Debug.Log("Button Right");
        IndexTot.value = Index[p, 0]/9f;
        IndexXau.value = Index[p, 1]/9f;
        IndexLay.value = Index[p, 2]/9f;
        IndexNuoc.value = Index[p, 3]/9f;
        IndexNhay.value = Index[p, 4]/9f;
    }

    void PlayOnClick(){
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You selected play "+ p.ToString());
    }    
    void BackOnClick(){
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You selected back");
    }
}
