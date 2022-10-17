using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.IO;

public class ControlGame : MonoBehaviour
{
    
    [SerializeField] private string _player;
    private GameObject Player;
    private GameObject Player1;
	private GameObject Player2;
	private GameObject Player3;
	private GameObject Player4;
    List<GameObject> PlayList ;
    private GameObject position1;
    private GameObject position2;
    private GameObject position3;
    private GameObject position4;
    private GameObject text;
    private bool check = true,start = false, endgame = false;
    [SerializeField] private int pointWin = 284;
    private string s = "";
    // Start is called before the first frame update
    void Start(){
        string path = "Assets/Resources/player.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path); 
        _player = reader.ReadToEnd();
        reader.Close();

        // TextAsset asset = Resources.Load<TextAsset>("player");
        // _player = asset.text;
        position1 = GameObject.Find("position1");
        position2 = GameObject.Find("position2");
        position3 = GameObject.Find("position3");
        position4 = GameObject.Find("position4");
        text = GameObject.Find("Text");
        text.GetComponent<UnityEngine.UI.Text>().text = "";
        StartCoroutine (delay1 ());
        // Player1.GetComponent<ControlPlay>().isPlayer = true;
        // if (Player == 2){Play2.GetComponent<ControlPlay>().isPlayer = true;}
        // if (Player == 3){Play3.GetComponent<ControlPlay>().isPlayer = true;}
        // if (Player == 4){Play4.GetComponent<ControlPlay>().isPlayer = true;}
    }

    // Update is called once per frame
    void Update()
    {
        try{
            if(Player1 != null || Player2 != null || Player3 != null || Player4 != null){
                if(!start){
                    start = true;
                    Player = PlayList[int.Parse(_player)-1];
                    for (int i = 0;i<4;i++){
                        if (i!=int.Parse(_player)-1){
                            PlayList[i].GetComponent<PlayItem>().Player = Player;
                        }
                        else{
                            PlayList[i].GetComponent<ControlPlay>().isPlayer = true;
                        }
                    }
                }
                if (!endgame){
                    Vector3 temp1 = Player1.transform.position;
                    Vector3 temp2 = Player2.transform.position;
                    Vector3 temp3 = Player3.transform.position;
                    Vector3 temp4 = Player4.transform.position;
                    List<GameObject> P = new List<GameObject>{position1, position2, position3, position4};
                    List<float> T = new List<float>{temp1.x, temp2.x, temp3.x, temp4.x};
                    int maxIndex = T.ToList().IndexOf(T.Max());
                    if(check){
                        position1.SetActive(true);
                        position2.SetActive(true);
                        position3.SetActive(true);
                        position4.SetActive(true);
                    
                        P[maxIndex].GetComponent<RectTransform>().anchoredPosition = new Vector3(260,123,0);
                        T.RemoveAt(maxIndex);
                        P.RemoveAt(maxIndex);
                        int minIndex = T.ToList().IndexOf(T.Min());
                        P[minIndex].GetComponent<RectTransform>().anchoredPosition = new Vector3(260,33,0);
                        T.RemoveAt(minIndex);
                        P.RemoveAt(minIndex);
                        if(T[0]>T[1]){
                            P[0].GetComponent<RectTransform>().anchoredPosition = new Vector3(260,93,0);
                            P[1].GetComponent<RectTransform>().anchoredPosition = new Vector3(260,63,0);
                        }
                        else{
                            P[1].GetComponent<RectTransform>().anchoredPosition = new Vector3(260,93,0);
                            P[0].GetComponent<RectTransform>().anchoredPosition = new Vector3(260,63,0);
                        }
                                
                        position1.GetComponent<UnityEngine.UI.Text>().text = ((int)temp1.x-17).ToString()+" m";
                        position2.GetComponent<UnityEngine.UI.Text>().text = ((int)temp2.x-17).ToString()+" m";
                        position3.GetComponent<UnityEngine.UI.Text>().text = ((int)temp3.x-17).ToString()+" m";
                        position4.GetComponent<UnityEngine.UI.Text>().text = ((int)temp4.x-17).ToString()+" m";
                    }
                    else{
                        position1.SetActive(false);
                        position2.SetActive(false);
                        position3.SetActive(false);
                        position4.SetActive(false);
                        P[maxIndex].SetActive(true);
                        P[maxIndex].GetComponent<RectTransform>().anchoredPosition = new Vector3(260,123,0);
                        P[maxIndex].GetComponent<UnityEngine.UI.Text>().text = ((int)T[maxIndex]-17).ToString()+" m";
                    }

                    if (temp1.x >pointWin){
                        Player1.GetComponent<PlayMove>().start = false;
                        if(Player1.GetComponent<PlayMove>().win == false){
                            s +="0";
                            Player1.GetComponent<PlayMove>().win = true;
                            }
                    }
                    if (temp2.x >pointWin){
                        Player2.GetComponent<PlayMove>().start = false;
                        if(Player2.GetComponent<PlayMove>().win == false){
                            s +="1";
                            Player2.GetComponent<PlayMove>().win = true;
                            }
                    }
                    if (temp3.x >pointWin){
                        Player3.GetComponent<PlayMove>().start = false;
                        if(Player3.GetComponent<PlayMove>().win == false){
                            s +="2";
                            Player3.GetComponent<PlayMove>().win = true;
                            }
                    }
                    if (temp4.x >pointWin){
                        Player4.GetComponent<PlayMove>().start = false;
                        if(Player4.GetComponent<PlayMove>().win == false){
                            s +="3";
                            Player4.GetComponent<PlayMove>().win = true;
                            }
                    }
                    if(s.Length == 4){
                        endgame =true;
                        if(s[0].ToString() == _player){
                            text.GetComponent<UnityEngine.UI.Text>().text = "Chuc mung ban da chien thang";
                        }
                        else{
                            text.GetComponent<UnityEngine.UI.Text>().text = "Ban da thua";
                        }
                    }
                }
                else{
                    //Debug.Log(s);
                }

            }
            else{
                Player1 = GameObject.FindWithTag("play1");
		        Player2 = GameObject.FindWithTag("play2");
		        Player3 = GameObject.FindWithTag("play3");
		        Player4 = GameObject.FindWithTag("play4");
                PlayList = new List<GameObject>{Player1,Player2,Player3,Player4};
                StartCoroutine (delay ());
            }
        }
        catch (Exception error){
            //Debug.Log(error.Message);
        }
    }
    IEnumerator delay(){
        yield return new WaitForSeconds (3);
        Player1.GetComponent<PlayMove>().start = true;
		Player2.GetComponent<PlayMove>().start = true;
		Player3.GetComponent<PlayMove>().start = true;
		Player4.GetComponent<PlayMove>().start = true;
    }

    IEnumerator delay1(){
        yield return new WaitForSeconds (10);
        check = !check;
        StartCoroutine (delay1 ());
    }

}
