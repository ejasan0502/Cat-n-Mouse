﻿using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {
    public int maxAttentionSpan = 10;
    public Transform player;
    public float atkD = 3f;
    public Transform[] nodes;

    private int nodeIndex = 0;
	private GameObject target = null;
    private EnemySight enemySight;
    private NavMeshAgent agent;

    private int attentionSpan = 0;

    void Awake(){
        enemySight = transform.GetChild(0).GetComponent<EnemySight>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update(){
        if ( target == null ){
            if ( nodes.Length > 0 ){
                if ( Vector3.Distance(transform.position,nodes[nodeIndex].position) <= 0.5f ){
                    if ( nodeIndex < nodes.Length-1 ){
                        nodeIndex++;
                    } else {
                        nodeIndex = 0;
                    }
                } else {
                    agent.SetDestination(nodes[nodeIndex].position);
                }
            }

            if ( enemySight.playerInSight ){
                target = GameObject.FindWithTag("Player");
                attentionSpan = maxAttentionSpan;
                StartCoroutine("Attention");
            }
        } else {
            if ( Vector3.Distance(transform.position,target.transform.position) <= atkD ){
                Attack();
            } else {
                agent.SetDestination(target.transform.position);
            }

            if ( enemySight.playerInSight ){
                attentionSpan = maxAttentionSpan;
            }
        }
    }

    private IEnumerator Attention(){
        while(true){
            yield return new WaitForSeconds(1f);
            attentionSpan--;
            if ( attentionSpan < 1 ){
                target = null;
                StopCoroutine("Attention");
            }
        }
    }

    private void Attack(){
        GameManager.instance.DisplayReset();
        target.GetComponent<Movement>().enabled = false;
    }
}
