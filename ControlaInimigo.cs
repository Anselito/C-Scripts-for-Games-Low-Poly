﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour, IMatavel
{

    public GameObject Jogador;
    public AudioClip SomAtaqueZumbi;
    private MovimentoPersonagem movimentaInimigo;
    private AnimacaoPersonagem animacaoInimigo;
    private Status statusInimigo;
    public AudioClip SomDeMorte;

    // Start is called before the first frame update
    void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");
        AleatorizarZumbis();
        animacaoInimigo = GetComponent<AnimacaoPersonagem>();
        movimentaInimigo = GetComponent<MovimentoPersonagem>();
        statusInimigo = GetComponent<Status>();
    }

    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        Vector3 direcao = Jogador.transform.position - transform.position;

        movimentaInimigo.Movimentar(direcao, statusInimigo.Velocidade);
        movimentaInimigo.Rotacionar(direcao);

        if (distancia > 2.5)
        {
            animacaoInimigo.Atacar(false);
        }
        else
        {
            animacaoInimigo.Atacar(true);
            ControlaAudio.instancia.PlayOneShot(SomAtaqueZumbi);

        }
    }

    void AtacaJogador()
    {
        int dano = Random.Range(20,30);
        Jogador.GetComponent<ControlaJogador>().TomarDano(dano);
    }

    void AleatorizarZumbis()
    {
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }

    public void TomarDano(int dano)
    {
        statusInimigo.Vida -= dano;
        if (statusInimigo.Vida <= 0) 
        {
            Morrer();        
        }
    }

    public void Morrer()
    {
        Destroy(gameObject);
        ControlaAudio.instancia.PlayOneShot(SomDeMorte);
    }   
}