using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    // Start is called before the first frame update
    public float Resize = 0.02F;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        this.gameObject.transform.localScale += new Vector3(Resize, Resize, 0);
    }

    void OnMouseExit()
    {
        // Reset the color of the GameObject back to normal
        this.gameObject.transform.localScale -= new Vector3(Resize, Resize, 0);
    }
}
