using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    [SerializeField]private GameObject Jogador;

    void Awake()
    {
        Jogador = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter() {
        PlayerController scriptPlayer = Jogador.GetComponent<PlayerController>();
        scriptPlayer.PowerCount += 1;
    }
}
