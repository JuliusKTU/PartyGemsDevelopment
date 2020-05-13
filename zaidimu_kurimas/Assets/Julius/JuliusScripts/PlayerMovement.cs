using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public BombControl BombContr;
    public GameObject Explosion;
    

    public float runSpeed = 40f;
    SpriteRenderer render;

    float horizontalMove = 10f;
    bool jump = false;
    public  bool hasBomb = true;
    private bool hasExploded = false;
    public bool shoudbedestoryed = false;

    


    void Start(){
        render = GetComponent<SpriteRenderer>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (hasBomb)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            render.material.SetColor("_Color", Color.red);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            render.material.SetColor("_Color", Color.white);
        }

        if (shoudbedestoryed && !hasExploded){
            GameObject a = Instantiate(Explosion) as GameObject;
            a.transform.position = gameObject.transform.position;
            Destroy(gameObject);
            hasExploded = true;

            Destroy(a, 0.35f);


            // Instantiate(Explosion, gameObject.transform);
        }

        
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    //called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player2" && hasBomb)
        {
            BombContr.ChangeTags(1, 2);
            Debug.Log("Collision");
        }

        if (col.gameObject.tag == "Player3" && hasBomb)
        {
            BombContr.ChangeTags(1, 3);
        }

        if (col.gameObject.tag == "Player4" && hasBomb)
        {
            BombContr.ChangeTags(1, 4);
        }

        if (col.gameObject.tag == "Shield" && hasBomb)
        {
            Debug.Log("Colision");
            BombContr.PassToNext(1);
            Destroy(col.gameObject);
        }

    }




}
