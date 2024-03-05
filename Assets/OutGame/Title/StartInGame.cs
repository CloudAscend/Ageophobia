using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartInGame : MonoBehaviour
{
    // Update is called once per frame
    public void InGameStart()
    {
        SceneManager.LoadScene("InGame");
    }
    
}
