using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullaDelEnemigo04 : MonoBehaviour
{
    [SerializeField] private GameObject enemigo;
    [SerializeField] private Transform[] puntosDeControl;
    [SerializeField] private float velocidad = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("RealizarMovimiento");
    }

    
    IEnumerator RealizarMovimiento()
    {
        for (int i = 0; i < puntosDeControl.Length; i++)
        {
            Vector3 nuevaPosicion = new Vector3(puntosDeControl[i].position.x, enemigo.transform.position.y, puntosDeControl[i].position.z);
            while (enemigo.transform.position != nuevaPosicion)
            {
                enemigo.transform.position = Vector3.MoveTowards(enemigo.transform.position, nuevaPosicion, velocidad * Time.deltaTime);
                yield return null;
            }
            if (i == puntosDeControl.Length - 2)
            {
                yield break;
            }
            //yield return new WaitForSeconds(3);
            yield return StartCoroutine("RotarEnemigo");
        }
        Debug.Log("Ha llegado al ultimo punto de control");
    }

    IEnumerator RotarEnemigo()
    {
        yield return new WaitForSecondsRealtime(3);
        for(int i = 1; i <= 90; i++)
        {
            enemigo.transform.Rotate(0, -1, 0);
        }
        yield return null;
    }
}
