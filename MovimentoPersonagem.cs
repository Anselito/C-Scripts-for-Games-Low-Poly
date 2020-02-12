using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPersonagem : MonoBehaviour
{
    private Rigidbody meuRigidBody;

    void Awake() 
    {
        meuRigidBody = GetComponent<Rigidbody>();
    }

    public void Movimentar(Vector3 direcao, float velocidade) 
    {
        meuRigidBody.MovePosition(GetComponent<Rigidbody>().position + direcao.normalized * velocidade * Time.deltaTime);
    }

    public void Rotacionar(Vector3 direcao)
    {
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        meuRigidBody.MoveRotation(novaRotacao);
    }
}
