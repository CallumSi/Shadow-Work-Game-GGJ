using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
}
