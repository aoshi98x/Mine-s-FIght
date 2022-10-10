using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeC : MonoBehaviour
{
    public bool isPaused= true;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }
    public void NoPause()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    
}
