using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    GameObject objective;
    NavMeshAgent agent;
    Animator enemyAnim;
    public bool kill = false;
    public bool isAttack = false;
    SphereCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyAnim = GetComponent<Animator>();
        objective = GameObject.Find ("Player");
        collider= GetComponent<SphereCollider>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        agent.SetDestination(objective.transform.position);
        if (agent.speed == 3.2f)
        {
            enemyAnim.SetBool("isWalk", true);
        }
        if(kill)
        {
            agent.speed = 0.0f;
            collider.enabled=false;
            isAttack = false;
            enemyAnim.SetBool("isDead", true);
            enemyAnim.SetBool("isWalk", false);
            enemyAnim.SetBool("isATK", false);
            StartCoroutine(DestroyThis());
           
        }
        
    }
    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            enemyAnim.SetBool("isATK", true);
            enemyAnim.SetBool("isWalk", false);
            agent.speed = 0.0f;
            isAttack = true;
        }
        if(other.gameObject.tag == "Damage")
        {
            kill = true;
        }
    }
    void OnTriggerExit (Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            agent.speed = 3.2f;
            enemyAnim.SetBool("isATK", false);
            enemyAnim.SetBool("isWalk", true);
            
        }
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }
}
