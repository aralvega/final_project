using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullaDelEnemigo03 : MonoBehaviour
{
    [SerializeField] private GameObject enemigo;
    [SerializeField] private Transform[] puntosDeControl;
    [SerializeField] private float velocidad = 1f;

    int i = 0;
    Vector3 nuevaPosicion;

    float tiempo = 0;
    bool sePuedeMover = false;
    // Start is called before the first frame update
    void Start()
    {
        nuevaPosicion = new Vector3(puntosDeControl[i].position.x, enemigo.transform.position.y, puntosDeControl[i].position.z);
    }

    // Update is called once per frame
    void Update()
    {
        RealizarMovimiento();
    }

    public void RealizarMovimiento()
    {
        if (i < puntosDeControl.Length)
        {
            if (sePuedeMover)
            {
                //enemigo.transform.position = Vector3.MoveTowards(enemigo.transform.position, puntosDeControl[i].transform.position, velocidad * Time.deltaTime);
                enemigo.transform.position = Vector3.MoveTowards(enemigo.transform.position, nuevaPosicion, velocidad * Time.deltaTime);
                if (enemigo.transform.position == /*puntosDeControl[i].transform.position*/nuevaPosicion)
                {
                    i++;
                    sePuedeMover = false;
                    tiempo = 0;
                    nuevaPosicion = new Vector3(puntosDeControl[i].position.x, enemigo.transform.position.y, puntosDeControl[i].transform.position.z);
                }
                if (i == puntosDeControl.Length)
                {
                    Debug.Log("Ha llegado al último punto de control");
                }

            }
            else
            {
                tiempo += Time.deltaTime;
                if (tiempo > 2)
                {
                    sePuedeMover = true;
                }
            }
        }
    }
}
