using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullaDelEnemigo01 : MonoBehaviour
{
    [SerializeField] private GameObject enemigo;
    [SerializeField] private Transform[] puntosDeControl;
    [SerializeField] private float velocidad = 1f;

    int i = 0;
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
        if (i < puntosDeControl.Length)
        {
            enemigo.transform.position = Vector3.MoveTowards(enemigo.transform.position, puntosDeControl[i].transform.position, velocidad * Time.deltaTime);
            
            if (enemigo.transform.position == puntosDeControl[i].transform.position)
            {
                i++;
                
            }
            if (i == puntosDeControl.Length)
            {
                Debug.Log("Ha llegado al último punto de control");
            }
        }
    }
}
