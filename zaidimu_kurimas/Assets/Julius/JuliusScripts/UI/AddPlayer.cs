using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject thirdPlayer;
    public GameObject fourthPlayer;
    public GameObject firstIcon;
    public GameObject secondIcon;
    public GameObject DeleteThirdPlayer;
    public static int howManyPlayers = 2;
    void Start()
    {
        DeleteThirdPlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.tag == "AddThird")
            {
                firstIcon.SetActive(false);
                secondIcon.SetActive(true);
                thirdPlayer.SetActive(true);
                DeleteThirdPlayer.SetActive(true);
                howManyPlayers++;
            }
            else if (hit.collider != null && hit.collider.gameObject.tag == "AddFourth")
            {
                secondIcon.SetActive(false);
                fourthPlayer.SetActive(true);
                DeleteThirdPlayer.SetActive(false);
                howManyPlayers++;
            }

            else if (hit.collider != null && hit.collider.gameObject.tag == "DeleteThird")
            {
                firstIcon.SetActive(true);
                secondIcon.SetActive(false);
                thirdPlayer.SetActive(false);
                howManyPlayers--;
            }
            else if (hit.collider != null && hit.collider.gameObject.tag == "DeleteFourth")
            {
                secondIcon.SetActive(true);
                fourthPlayer.SetActive(false);
                DeleteThirdPlayer.SetActive(true);
                howManyPlayers--;
            }
        }
    }

}
