using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField]public bool isNav;
    private NavMeshAgent inimigo;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        inimigo = GetComponent<NavMeshAgent>();
        isNav = false;
    }
    
    void Update()
    {
        transform.LookAt(player.transform);

        if(isNav)
        {
            inimigo.SetDestination(player.transform.position);
        }
    }
}
