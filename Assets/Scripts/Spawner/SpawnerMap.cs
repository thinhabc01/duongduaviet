using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class SpawnerMap : MonoBehaviour
{
    [SerializeField] private enum Map{Map1, Map2, Map3, Map4, Map5, Map6, Map7, Map8, Map9}
    [SerializeField] private Map map;

    [SerializeField] private GameObject Spawner0;
    [SerializeField] private GameObject Spawner1;
    [SerializeField] private GameObject Spawner2;
    [SerializeField] private GameObject Spawner3;
    [SerializeField] private GameObject Spawner4;
    [SerializeField] private GameObject Spawner5;
    [SerializeField] private GameObject Spawner6;
    [SerializeField] private GameObject Spawner7;
    [SerializeField] private GameObject Spawner8;
    [SerializeField] private GameObject Spawner9;
    [SerializeField] private GameObject Spawner10;
    [SerializeField] private GameObject Spawner11;
    [SerializeField] private GameObject Spawner12;
    [SerializeField] private GameObject Spawner13;
    [SerializeField] private GameObject Spawner14;
    [SerializeField] private GameObject Spawner15;
    [SerializeField] private GameObject Spawner16;

    [SerializeField] private GameObject Item1;
    [SerializeField] private GameObject Item2;
    [SerializeField] private GameObject Item3;

    [SerializeField] private GameObject _Voi;
    [SerializeField] private GameObject _Cho;
    [SerializeField] private GameObject _Ga;

    [SerializeField] private GameObject Play1;
    [SerializeField] private GameObject Play2;
    [SerializeField] private GameObject Play3;
    [SerializeField] private GameObject Play4;

    [SerializeField] private GameObject May;
    [SerializeField] private GameObject R;
    [SerializeField] private GameObject Sky;
    [SerializeField] private GameObject W;
    [SerializeField] private GameObject Back;
    [SerializeField] private GameObject Bg1;
    [SerializeField] private GameObject Bg2;
    [SerializeField] private GameObject T;

    //item position
    int[] ItemPositionX = new int[] {};
    int[] ItemPositionY = new int[] {};
    //enemy position
    int[]  ChoPositionX = new int[] {};
    int[]  ChoPositionY = new int[] {};
    int[]  VoiPositionX = new int[] {};
    int[]  VoiPositionY = new int[] {};
    int[]   GaPositionX = new int[] {};
    int[]   GaPositionY = new int[] {};

    private int[,] aX = {{ 20, 21, 20, 21 }, { 17, 18, 17, 18 }, { 17, 18, 19, 20 }, { 16, 17, 16, 17 }, { 17, 18, 19, 20 }, { 17, 18, 19, 20 }, { 17, 18, 17, 18 }, { 17, 18, 19, 20 }, { 17, 18, 17, 18 } };
	private int[,] aY = {{ 9, 9, 6, 6 }, { 6, 6, 9, 9 }, { 9, 9, 9, 9 }, { 7, 7, 4, 4 }, { 9, 9, 9, 9 }, { 8, 8, 8, 8 }, { 9, 9, 5, 5 }, { 9, 9, 9, 9 }, { 7, 7, 4, 4 } };


    List<List<string>> ListOjb = new List<List<string>>{};
    List<GameObject> ListGameObj;
    List<GameObject> ListPlay;
    string namefile;
    int M;
    // Start is called before the first frame update
    void Start(){

        ListPlay = new List<GameObject>{Play1, Play2, Play3, Play4};
        ListGameObj = new List<GameObject>{null,Spawner1,Spawner2,Spawner3,Spawner4,Spawner5,
                            Spawner6,Spawner7,Spawner8,Spawner9,Spawner10,Spawner11,Spawner12,
                            Spawner13,Spawner14,Spawner15,Spawner16};
        if (map == Map.Map1){
            M = 1;
            namefile ="data1";
            //item position
            ItemPositionX = new int[] { 67, 68, 69, 117, 118, 119, 212, 213, 214 };
            ItemPositionY = new int[] { 6, 6, 6, 9, 9, 9, 8, 8, 8 };
            //enemy position
            ChoPositionX = new int[] { 30, 87, 116 };
            ChoPositionY = new int[] { 9, 9, 9 };
            VoiPositionX = new int[] { 71, 181, 252 };
            VoiPositionY = new int[] { 9, 9, 8 };
            GaPositionX = new int[] { 38, 107, 218 };
            GaPositionY = new int[] { 9, 9, 9 };
            // _sky = "sky1";
            // _w = "w1";
            // _back = "back2";
            // _bg1 = "bg0";
            // _bg2 = "bg4";
            // _t = "t1";
        }
        if (map == Map.Map2){
            M = 2;
            namefile ="data2";
            //item position
            ItemPositionX = new int[] { 37, 39, 42, 134, 135, 136, 198, 199, 200 };
            ItemPositionY = new int[] { 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            //enemy 
            ChoPositionX = new int[] { 204 };
            ChoPositionY = new int[] { 9 };
            VoiPositionX = new int[] { 26, 30, 153, 234 };
            VoiPositionY = new int[] { 9, 9, 10, 10 };
            GaPositionX = new int[] { 62, 202, 169, 49 };
            GaPositionY = new int[] { 10, 9, 9, 9 };
            // _sky = "sky";
            // _w = "w";
            // _back = "back0";
            // _bg1 = "bg6";
            // _bg2 = "bg2";
            // _t = "t0";
        }
        if (map == Map.Map3){
            M = 3;
            namefile ="data3";
            //item position
            ItemPositionX = new int[] { 33, 34, 35, 131, 135, 139, 192, 198, 204 };
            ItemPositionY = new int[] { 9, 9, 9, 9, 9, 9, 6, 6, 6 };
            //enemy
            ChoPositionX = new int[] { 27, 65, 182, 212, 270 };
            ChoPositionY = new int[] { 9, 9, 9, 9, 7 };
            VoiPositionX = new int[] { 127, 167, 247 };
            VoiPositionY = new int[] { 9, 9, 9 };
            // _sky = "sky";
            // _w = "w";
            // _back = "back4";
            // _bg1 = "bg7";
            // _bg2 = "bg5";
            // _t = "t0";
        }
        if (map == Map.Map4){
            M = 4;
            namefile ="data4";
            //item position
            ItemPositionX = new int[] { 29, 30, 31, 107, 108, 109, 185, 186, 187 };
            ItemPositionY = new int[] { 7, 7, 7, 8, 8, 8, 8, 8, 8 };
            //enemy
            ChoPositionX = new int[] { 86, 96, 218, 248, 272, 172 };
            ChoPositionY = new int[] { 9, 9, 7, 8, 8, 8 };
            // _may = "may";
            // _r = "r";
            // _sky = "sky";
            // _w = "w";
            // _back = "back1";
            // _bg1 = "bg3";
            // _bg2 = "bg5";
            // _t = "t0";
        }
        if (map == Map.Map5){
            M = 5;
            namefile ="data5";
            //item position
            ItemPositionX = new int[] { 47, 53, 67, 69, 95, 172, 174, 178, 180 };
            ItemPositionY = new int[] { 9, 9, 9, 8, 8, 8, 8, 8, 8 };
            // _sky = "sky2";
            // _w = "w2";
            // _back = "back3";
            // _bg1 = "bg9";
            // _bg2 = "bg8";
            // _t = "t2";
        }
        if (map == Map.Map6){
            M = 6;
            namefile ="data6";
            //item position
            ItemPositionX = new int[] { 85, 87, 90, 139, 143, 199, 228, 232, 235 };
            ItemPositionY = new int[] { 8, 8, 8, 9, 9, 9, 9, 9, 9 };
            // _sky = "sky1";
            // _w = "w1";
            // _back = "back5";
            // _bg1 = "bg10";
            // _bg2 = "bg11";
            // _t = "t1";
        }
        if (map == Map.Map7){
            M = 7;
            namefile ="data7";
            //item position
            ItemPositionX = new int[] { 28, 29, 30, 76, 77, 78, 148, 149, 150 };
            ItemPositionY = new int[] { 6, 5, 6, 8, 7, 8, 7, 7, 7 };
            // _sky = "sky2";
            // _w = "w2";
            // _back = "back6";
            // _bg1 = "bg13";
            // _bg2 = "bg12";
            // _t = "t2";
        }
        if (map == Map.Map8){
            M = 8;
            namefile ="data8";
            //item position
            ItemPositionX = new int[] { 41, 44, 52, 153, 154, 155, 221, 223, 225 };
            ItemPositionY = new int[] { 6, 9, 8, 8, 9, 8, 9, 8, 8 };
            // _may = "may";
            // _r = "r";
            // _sky = "sky";
            // _w = "w";
            // _back = "back1";
            // _bg1 = "bg16";
            // _bg2 = "bg1";
            // _t = "t0";
        }
        if (map == Map.Map9){
            M = 9;
            namefile ="data9";
            //item position
            ItemPositionX = new int[] { 40, 41, 42, 97, 98, 99, 192, 193, 194 };
            ItemPositionY = new int[] { 9, 9, 9, 8, 7, 6, 10, 10, 10 };
            // _sky = "sky1";
            // _w = "w1";
            // _back = "back2";
            // _bg1 = "bg14";
            // _bg2 = "bg15";
            // _t = "t1";
            
        }
        _readplayindex();
        _readmap();
        _Spawner ();
        // _drawBackGround();  
    }
    // void _drawBackGround(){
    //     SKY = Resources.Load<Sprite>(_sky);
    //     W = Resources.Load<Sprite>(_w);
    //     BACK = Resources.Load<Sprite>(_back);
    //     BG1 = Resources.Load<Sprite>(_bg1);
    //     BG2 = Resources.Load<Sprite>(_bg2);
    //     T = Resources.Load<Sprite>(_t);

    //     _May = GameObject.FindWithTag("may");
    //     _R = GameObject.FindWithTag("r");
    //     _W = GameObject.FindWithTag("w");
    //     _Back = GameObject.FindWithTag("back");
    //     _Bg1 = GameObject.FindWithTag("bg1");
    //     _Bg2 = GameObject.FindWithTag("bg2");
    //     _T = GameObject.FindWithTag("t");
    //     _Sky = GameObject.FindWithTag("sky");

    //     _W.GetComponent<SpriteRenderer> ().sprite = W;
    //     _Bg1.GetComponent<SpriteRenderer> ().sprite = BG1;
    //     _Bg2.GetComponent<SpriteRenderer> ().sprite = BG2;
    //     _T.GetComponent<SpriteRenderer> ().sprite = T;
    //     _Back.GetComponent<Image>().sprite = BACK;
    //     _Sky.GetComponent<Image>().sprite = SKY;
    //     if (_may != "may"){
    //         _May.SetActive(false);
    //         _R.SetActive(false);
    //     }
    // }
    void _readmap(){
        
        string readFromFilePath = Application.streamingAssetsPath + "/Resources/" + namefile + ".txt";
        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();
        for (int i =0;i<fileLines.Count;i++){
            List<string> temp =  new List<string>(fileLines[i].Split(' '));
            ListOjb.Add(temp);
        }
    }
    void _readplayindex(){
        // 0 play number
        // 1 number of monney
        // 2 chi so duong tot
        // 3 chi so duong xau
        // 4 chi so duong lay
        // 5 chi so duong nuoc
        // 6 chi so nhay
        string readFromFilePath = Application.streamingAssetsPath + "/Resources/Play.txt";
        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();
        int __play = int.Parse(fileLines[0]);
        int __money = int.Parse(fileLines[1]);
        float tot_index = float.Parse(fileLines[2]);
        float xau_index = float.Parse(fileLines[3]);
        float lay_index = float.Parse(fileLines[4]);
        float nuoc_index = float.Parse(fileLines[5]);
        float nhay_index = float.Parse(fileLines[6]);
        // Debug.Log(__play+ nhay_index);
    }
    void _Spawner(){
        for (int i=0 ;i <ListOjb.Count ;i++){
            for (int j=0 ;j<ListOjb[10-i].Count;j++){
                Vector3 temp = new Vector3(j,i,0);
                try{
                    Instantiate (ListGameObj[int.Parse(ListOjb[10-i][j])], temp, Quaternion.identity);
                }
                catch (Exception error){}
            }
        }

        for (int i=0;i< ItemPositionX.Length/3;i++){
            Vector3 temp1 = new Vector3(ItemPositionX[3*i+0], 11-ItemPositionY[3*i+0], 0);
            Instantiate (Item2, temp1, Quaternion.identity);
            Vector3 temp2 = new Vector3(ItemPositionX[3*i+1], 11-ItemPositionY[3*i+1], 0);
            Instantiate (Item3, temp2, Quaternion.identity);
            Vector3 temp3 = new Vector3(ItemPositionX[3*i+2], 11-ItemPositionY[3*i+2], 0);
            Instantiate (Item1, temp3, Quaternion.identity);
        } 
        for (int i=0;i< ChoPositionX.Length;i++){
            Vector3 temp1 = new Vector3(ChoPositionX[i], 11-ChoPositionY[i], 0);
            Instantiate (_Cho, temp1, Quaternion.identity);
        } 
        for (int i=0;i< GaPositionX.Length;i++){
            Vector3 temp1 = new Vector3(GaPositionX[i], 11-GaPositionY[i], 0);
            Instantiate (_Ga, temp1, Quaternion.identity);
        } 
        for (int i=0;i< VoiPositionX.Length;i++){
            Vector3 temp1 = new Vector3(VoiPositionX[i], 11-VoiPositionY[i], 0);
            Instantiate (_Voi, temp1, Quaternion.identity);
        } 
        for(int i=0;i<4;i++){
            Vector3 temp = new Vector3(aX[M-1, i], 11- aY[M-1, i], 0);
            Instantiate (ListPlay[i], temp, Quaternion.identity);
        }

    }
}