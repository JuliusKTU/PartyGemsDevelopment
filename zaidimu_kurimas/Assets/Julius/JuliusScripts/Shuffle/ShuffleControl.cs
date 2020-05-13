using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShuffleControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    public Text title;
    public Text description;
    public float StopAfter = 11.5f;
    private float delay = 1.5f; 

    public static bool StartGame = false;
    private bool zoomed = false;

    private int sceneToLoad = 1;
    public GameObject playButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StopAfter -= Time.deltaTime;

        if(StopAfter<= 0)
        {
            if(sceneToLoad == 2){

                animator.SetInteger("selectScene", 2);
                title.text = "Rush to the exam";
                description.text = "Hurry up, the exam is already started!";
                StartGame = true;
            }
            else if (sceneToLoad == 1){
                animator.SetInteger("selectScene", 1);
                title.text = "Explosive chemistry lab";
                description.text = "Get away from the suspicious chemicals, they can explode at any time!";
                StartGame = true;
            }
            
            

            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                playButton.SetActive(true);
                //if (!zoomed)
                //{
                //    this.gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0);
                //    zoomed = true;
                //}
                


            }
        }
    }
}
