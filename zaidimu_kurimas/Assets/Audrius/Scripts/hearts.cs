using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class hearts : MonoBehaviour
{
    // Start is called before the first frame update
    public Image[] heart;
    int count = -1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle" && count < 3)
        {
            if (gameObject.tag == "Player1")
            {
                transform.position = new Vector2(-8, -3.6f);
            }
            if (gameObject.tag == "Player2")
            {
                transform.position = new Vector2(8, -3.6f);
            }
            count++;
            heart[count].enabled = false;
            if (count == 2)
            {
                Destroy(gameObject);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "apple" && count < 3)
        {
            heart[count].enabled = true;
            count--;
            collision.gameObject.SetActive(false);
        }
    }
}
