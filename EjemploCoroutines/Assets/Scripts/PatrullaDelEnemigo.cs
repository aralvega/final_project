using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullaDelEnemigo : MonoBehaviour
{
    [SerializeField] private GameObject enemigo;
    [SerializeField] private Transform[] puntosDeControl;
    [SerializeField] private float velocidad = 1f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RealizarMovimiento();
    }

    void RealizarMovimiento()
    {
        for (int i = 0; i < puntosDeControl.Length; i++)
        {
            while (enemigo.transform.position != puntosDeControl[i].position)
            {
                enemigo.transform.position = Vector3.MoveTowards(enemigo.transform.position, puntosDeControl[i].transform.position, velocidad * Time.deltaTime);

            }
        }
        Debug.Log("Ha llegado al ultimo punto de control");
    }


    
}
