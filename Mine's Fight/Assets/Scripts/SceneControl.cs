using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public string nameScene;
    // Start is called before the first frame update
    public void SceneChange()
    {
        SceneManager.LoadScene(nameScene);
    }
}
