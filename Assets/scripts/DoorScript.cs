using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]private GameObject door;
    [SerializeField]private GameObject[] inimigos;
    private Renderer rend;

    private void Awake() {
        rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.green);

        inimigos = GameObject.FindGameObjectsWithTag("Enemy");
    }
    
    private void OnTriggerEnter() {
        rend.material.SetColor("_Color", Color.red);
        Destroy(door);

        foreach (GameObject inimigo in inimigos)
        {
            EnemyController scriptInimigo = inimigo.GetComponent<EnemyController>();
            scriptInimigo.isNav = true;
        }
    }
}
