using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullaDelEnemigo05 : MonoBehaviour
{
    [SerializeField] private GameObject enemigo;
    [SerializeField] private Transform[] puntosDeControl;
    [SerializeField] private float velocidad = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("RealizarMovimiento");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("RealizarMovimiento");
            //StopAllCoroutines;
        }
    }


    IEnumerator RealizarMovimiento()
    {
        int i = 0;
        Vector3 nuevaPosicion = new Vector3(puntosDeControl[i].position.x, enemigo.transform.position.y, puntosDeControl[i].position.z);

        while (true)
        {
            while (enemigo.transform.position != nuevaPosicion)
            {
                enemigo.transform.position = Vector3.MoveTowards(enemigo.transform.position, nuevaPosicion, velocidad * Time.deltaTime);
                yield return null;
            }
            yield return StartCoroutine("RotarEnemigo");
            if (i < puntosDeControl.Length-1)
            {
                i++;
            }
            else
            {
                i = 0;
            }
            nuevaPosicion = new Vector3(puntosDeControl[i].position.x, enemigo.transform.position.y, puntosDeControl[i].position.z);
            Debug.Log(i);
        }
        
    }

    IEnumerator RotarEnemigo()
    {
        yield return new WaitForSecondsRealtime(2);
        for (int i = 1; i <= 90; i++)
        {
            enemigo.transform.Rotate(0, -1, 0);
        }
        yield return null;
    }
}
