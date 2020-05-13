using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBuff : MonoBehaviour
{
    public BuffsManager buffs;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.IndexOf("Player")==0)
        {
            ApplyRandomBuff(col.gameObject);
            buffs.SetBuffedPlayer(col.gameObject);

            Destroy(gameObject);
        }
    }


    private void ApplyRandomBuff(GameObject player)
    {
        int BuffNumber = Random.Range(0, 4);

        if (BuffNumber == 0) //Increase speed
        {
            Debug.Log("Speed was increased");
            player.GetComponent<PlayerMovement>().runSpeed += 100;
            player.GetComponent<CharacterController2D>().IncreaseJumpSpeed(100);
        }
        else if (BuffNumber == 1)
        {
            Debug.Log("Jum was increased");
            player.GetComponent<CharacterController2D>().IncreaseJumpSpeed(300);
            
        }
        else if (BuffNumber == 2)
        {
            Debug.Log("Jump was decreased");
            player.GetComponent<CharacterController2D>().IncreaseJumpSpeed(-180);
        }
        else if (BuffNumber == 3)
        {
            Debug.Log("Speed was decreased");
            player.GetComponent<PlayerMovement>().runSpeed -= 100;
        }
        //else
        //{
        //    return "No defined";
        //}

    }

    

}
