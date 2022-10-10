using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmeraldPoints : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(DestroyFunc());
        }
    }
    IEnumerator DestroyFunc()
    {
        yield return new WaitForSeconds (0.7f);
        Destroy(this.gameObject);

    }
}
