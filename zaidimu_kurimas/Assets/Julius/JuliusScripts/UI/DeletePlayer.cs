using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ThirdPlayer;
    public GameObject FourthPlayer;
    public GameObject AddThirdPlayer;
    public GameObject AddFourthPlayer;
    public GameObject DeleteThirdPlayer;
    public static int PlayerCount = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.tag == "DeleteThird")
            {
                AddThirdPlayer.SetActive(true);
                ThirdPlayer.SetActive(false);
            }
            else if (hit.collider != null && hit.collider.gameObject.tag == "DeleteFourth")
            {
                AddFourthPlayer.SetActive(true);
                FourthPlayer.SetActive(false);
            }
        }
    }
}
