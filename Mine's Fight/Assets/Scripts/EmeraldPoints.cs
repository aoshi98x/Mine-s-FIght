using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmeraldPoints : MonoBehaviour
{
    AudioSource points;
    // Start is called before the first frame update
    void Start()
    {
        points = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            points.Play();
            StartCoroutine(DestroyFunc());
        }
    }
    IEnumerator DestroyFunc()
    {
        yield return new WaitForSeconds (0.7f);
        Destroy(this.gameObject);

    }
}
