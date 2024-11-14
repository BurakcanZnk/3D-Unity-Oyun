using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float enemyHP = 100;
    Animator enemyAnim;
    bool enemydead;
    float mesafe;
    public float kovalamaMesafesi;
    public float saldirmaMesafesi;
    NavMeshAgent enemyNavMesh;
    GameObject hedefOyuncu;

    void Start()
    {
        enemyAnim = this.GetComponent<Animator>();
        hedefOyuncu = GameObject.FindWithTag("Player");
        enemyNavMesh = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (enemyHP <= 0)
        {
            enemydead = true;
        }
        if (enemydead == true)
        {
            enemyAnim.SetBool("dead", true);
            StartCoroutine(YokOl());
        }
        else
        {
            mesafe = Vector3.Distance(this.transform.position, hedefOyuncu.transform.position);
            if (mesafe < kovalamaMesafesi)
            {
                enemyNavMesh.isStopped = false;
                enemyNavMesh.SetDestination(hedefOyuncu.transform.position);
                enemyAnim.SetBool("running", true);
                enemyAnim.SetBool("attack", false);
            }
            else
            {
                enemyNavMesh.isStopped = true;
                enemyAnim.SetBool("running", false);
                enemyAnim.SetBool("attack", false);
            }
            if(mesafe < saldirmaMesafesi)
            {
                enemyNavMesh.isStopped = true;
                enemyAnim.SetBool("running", false);
                enemyAnim.SetBool("attack", true);
            }
        }
    }

    public void HasarVer()
    {
        //hedefOyuncu.GetComponent<KarakterKontrol>().HasarAl();
    }

    IEnumerator YokOl()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }
    public void HasarAl()
    {
        enemyHP -= Random.Range(15, 25);
    }
}
