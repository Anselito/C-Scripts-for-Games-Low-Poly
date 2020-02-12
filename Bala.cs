using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float Velocidade = 20;
    private Rigidbody rigidbodyBala;
    private Animator animatorBala;
    public AudioClip SomDeMorte;
    private int danoDoTiro = 1;

    void start() 
    {
        rigidbodyBala = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * Velocidade * Time.deltaTime);
    }

    void OnTriggerEnter(Collider objetoDeColisao)
    {
        if (objetoDeColisao.tag == "Inimigo")
        {
            objetoDeColisao.GetComponent<ControlaInimigo>().TomarDano(danoDoTiro);
        }

        Destroy(gameObject);
    }
}
