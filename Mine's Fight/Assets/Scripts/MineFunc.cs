using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineFunc : MonoBehaviour
{
    public bool isMiner = false;
    PlayerController minerFunc;
    public GameObject emerald;
    Transform mine;
    public float mineLife = 20.5f;
    public float time;
    void Start()
    {
        minerFunc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        mine = GetComponent<Transform>();
    }
    void Update()
    {
        if (isMiner && minerFunc.isAtacking)
        {
            time+=4*Time.deltaTime;
            mineLife = mineLife - 0.9f;
            if(mineLife <= 0.0f)
            {
                StartCoroutine (EmeraldAppear());
                StartCoroutine (DestroyMine());
            }
        }
    }
    // Start is called before the first frame update
    void OnTriggerStay (Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isMiner=true;
        }
    }
    IEnumerator EmeraldAppear()
    {
        yield return new WaitForSeconds(1.0f);
        if(time>=4)
        {     
            Instantiate(emerald, mine.position, Quaternion.identity);
            time=0;  
        }
        
    }
    IEnumerator DestroyMine()
    {
        yield return new WaitForSeconds(1.8f);     
        Destroy(this.gameObject);
    }
}
