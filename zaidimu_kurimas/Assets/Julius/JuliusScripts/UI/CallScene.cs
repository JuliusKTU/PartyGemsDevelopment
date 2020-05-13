using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallScene : MonoBehaviour
{
    public void buttonChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
        Debug.Log("Clicked");
    }
}
