using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombControl : MonoBehaviour
{

    public PlayerMovement firstPlayer;
    public SecondPlayerMovement secondPlayer;
    public ThirdPlayerMovement thirdPlayer;
    public FourthPlayerMovement fourthPlayer;

    public float coolDown = 0.5f;
    private float coolDownTimer = 0.5f;

    public float BombExplodesAfter = 5;
    float BombExplodes;
    public Shake chameraShake;
    public Text BombTimerText;

    public int playersCount = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        BombExplodes = BombExplodesAfter;
        playersCount = AddPlayer.howManyPlayers;
        SelectPlayers(playersCount);
        BombTimerText.text = "Hurry up! Potion will explode at any time!";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (coolDownTimer>0){
            coolDownTimer -= Time.deltaTime;
        }

        if (coolDownTimer<0){
            coolDownTimer = 0;
        }

        if (BombExplodes>0){
            BombExplodes -= Time.deltaTime;
        }

        if (CheckIfGameHasEnded())
        {
            BombTimerText.text = WhichHasWon();
            firstPlayer.hasBomb = false;
            secondPlayer.hasBomb = false;
            thirdPlayer.hasBomb = false;
            fourthPlayer.hasBomb = false;
        }
        else
        {
            if (BombExplodes < 5)
            {
                BombTimerText.text = Convert.ToString(Math.Round(BombExplodes));
            }

        }
        
        //Debug.Log(coolDownTimer);

        if (BombExplodes<0){

            StartCoroutine(chameraShake.CameraShake(.25f, .55f));

            if (firstPlayer.hasBomb){
            
                firstPlayer.shoudbedestoryed = true;
                playersCount--;
                if(playersCount != 1)
                {
                    PassToNext(1);
                }
                
            }

            else if (secondPlayer.hasBomb){

                secondPlayer.shoudbedestoryed = true;
                playersCount--;
                if(playersCount != 1)
                {
                    PassToNext(2);
                }
                
            }

            else if (thirdPlayer.hasBomb)
            {

                thirdPlayer.shoudbedestoryed = true;
                playersCount--;
                if(playersCount != 1)
                {
                    PassToNext(3);
                }
                
            }

            else if (fourthPlayer.hasBomb)
            {

                fourthPlayer.shoudbedestoryed = true;
                playersCount--;
                if(playersCount != 1)
                {
                    PassToNext(4);
                }
                
            }
            BombTimerText.text = "Hurry up! Potion will explode at any time!";
            BombExplodes = BombExplodesAfter;
        }

    }

    public void ChangeTags(int playera, int playerb){

        if (coolDownTimer <= 0){

            coolDownTimer = coolDown;

            if (playera == 1 && playerb == 2)
            {
                Debug.Log("TAIP2");
                firstPlayer.hasBomb = false;
                secondPlayer.hasBomb = true;
            }

            else if (playera == 1 && playerb == 3)
            {
                Debug.Log("TAIP3");
                firstPlayer.hasBomb = false;
                thirdPlayer.hasBomb = true;
            }

            else if (playera == 1 && playerb == 4)
            {
                Debug.Log("TAIP4");
                firstPlayer.hasBomb = false;
                fourthPlayer.hasBomb = true;
            }

            else if (playera == 2 && playerb == 1)
            {
                Debug.Log("TAIP1");
                secondPlayer.hasBomb = false;
                firstPlayer.hasBomb = true;
            }

            else if (playera == 2 && playerb == 3)
            {
                Debug.Log("TAIP3");
                secondPlayer.hasBomb = false;
                thirdPlayer.hasBomb = true;
            }

            else if (playera == 2 && playerb == 4)
            {
                Debug.Log("TAIP4");
                secondPlayer.hasBomb = false;
                fourthPlayer.hasBomb = true;
            }

            else if (playera == 3 && playerb == 1)
            {
                Debug.Log("TAIP1");
                thirdPlayer.hasBomb = false;
                firstPlayer.hasBomb = true;
            }

            else if (playera == 3 && playerb == 2)
            {
                Debug.Log("TAIP2");
                thirdPlayer.hasBomb = false;
                secondPlayer.hasBomb = true;
            }

            else if (playera == 3 && playerb == 4)
            {
                Debug.Log("TAIP4");
                thirdPlayer.hasBomb = false;
                fourthPlayer.hasBomb = true;
            }

            else if (playera == 4 && playerb == 1)
            {
                Debug.Log("TAIP1");
                fourthPlayer.hasBomb = false;
                firstPlayer.hasBomb = true;
            }

            else if (playera == 4 && playerb == 2)
            {
                Debug.Log("TAIP2");
                fourthPlayer.hasBomb = false;
                secondPlayer.hasBomb = true;
            }

            else if (playera == 4 && playerb == 3)
            {
                Debug.Log("TAIP3");
                fourthPlayer.hasBomb = false;
                thirdPlayer.hasBomb = true;
            }

        }
        
    }

    public void PassToNext(int current)
    {
        if(current == 1)
        {
            if(secondPlayer.shoudbedestoryed == false)
            {
                ChangeTags(1, 2);
            }
            else if(thirdPlayer.shoudbedestoryed == false)
            {
                ChangeTags(1, 3);
            }
            else if (fourthPlayer.shoudbedestoryed == false)
            {
                ChangeTags(1, 4);
            }
        }
        else if (current == 2)
        {
            if (thirdPlayer.shoudbedestoryed == false)
            {
                ChangeTags(2, 3);
            }
            else if (fourthPlayer.shoudbedestoryed == false)
            {
                ChangeTags(2, 4);
            }
            else if (firstPlayer.shoudbedestoryed == false)
            {
                ChangeTags(2, 1);
            }
        }
        else if (current == 3)
        {

            if (fourthPlayer.shoudbedestoryed == false)
            {
                ChangeTags(3, 4);
            }
            else if (firstPlayer.shoudbedestoryed == false)
            {
                ChangeTags(3, 1);
            }
            else if (secondPlayer.shoudbedestoryed == false)
            {
                ChangeTags(3, 2);
            }
        }
        else if (current == 4)
        {

            if (firstPlayer.shoudbedestoryed == false)
            {
                ChangeTags(4, 1);
            }
            else if (secondPlayer.shoudbedestoryed == false)
            {
                ChangeTags(4, 2);
            }
            else if (thirdPlayer.shoudbedestoryed == false)
            {
                ChangeTags(4, 3);
            }
        }
    }

    private bool CheckIfGameHasEnded()
    {
        if (playersCount == 1)
            return true;
        else return false;
    }

    private string WhichHasWon()
    {
        if(firstPlayer.shoudbedestoryed == false)
        {
            return "FIRST PLAYER HAS WON";
        }
        else if (secondPlayer.shoudbedestoryed == false)
        {
            return "SECOND PLAYER HAS WON";
        }
        else if (thirdPlayer.shoudbedestoryed == false)
        {
            return "THIRD PLAYER HAS WON";
        }
        else if (fourthPlayer.shoudbedestoryed == false)
        {
            return "FOURTH PLAYER HAS WON";
        }
        else
        {
            return "NO ONE HAS WON";
        }
    }

    private void SelectPlayers(int playerCount)
    {
        if (playersCount == 4)
            return;

        else if(playersCount == 3)
        {
            fourthPlayer.shoudbedestoryed = true;
        }

        else if(playersCount == 2)
        {
            fourthPlayer.shoudbedestoryed = true;
            thirdPlayer.shoudbedestoryed = true;
        }
    }

    
}
