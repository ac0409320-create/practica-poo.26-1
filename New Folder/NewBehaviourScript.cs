using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody rb;                     // 'Rigidbody' debe ir con may�scula
    public float fuerza = 1000f;
    public float velocidadApuntador = 5f;
    public float limiteIzquierdo = -1.0f;    // Valores ajustados a algo l�gico
    public float limiteDerecho = 1.0f;

    private bool haSidoLanzada = false;      // Declarada la variable correctamente

    void Update()
    {
        if (!haSidoLanzada)
        {
            Apuntar();

            // Detecta si el jugador presiona la barra espaciadora
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Lanzar();
            }
        }
    }

    void Apuntar()
    {
        float inputHorizontal = Input.GetAxis("Horizontal"); // "Horizontal" con H may�scula
        transform.Translate(Vector3.right * inputHorizontal * velocidadApuntador * Time.deltaTime);

        Vector3 posicionActual = transform.position;
        posicionActual.x = math.clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);
        transform.position = posicionActual;
    }

    void Lanzar()
    {
        haSidoLanzada = true;
        rb.AddForce(Vector3.forward * fuerza); // 'AddForce' con A may�scula
    }
}
//boliche
