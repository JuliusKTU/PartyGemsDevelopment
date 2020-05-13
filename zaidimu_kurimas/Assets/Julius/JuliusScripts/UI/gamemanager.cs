using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public int PlayersCount = 3;
    public int Victorious = 4;
    void Start()
    {
        if(PlayersCount == 2){
            transform.parent.gameObject.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            transform.parent.gameObject.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else if(PlayersCount == 3){
            transform.parent.gameObject.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }

        if(Victorious == 1){
            
            // GameObject.Find("Cap1").SetActive(true);
            transform.parent.gameObject.transform.GetChild(5).gameObject.SetActive(true);
        }
        else if(Victorious == 2){
            transform.parent.gameObject.transform.GetChild(9).gameObject.SetActive(true);
        }
        else if (Victorious == 3){
            transform.parent.gameObject.transform.GetChild(10).gameObject.SetActive(true);
        }
        else if(Victorious == 4){
            transform.parent.gameObject.transform.GetChild(11).gameObject.SetActive(true);
        }   


    }

    public void SetResults (int players, int victorious){
        PlayersCount = players;
        Victorious = victorious;
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
