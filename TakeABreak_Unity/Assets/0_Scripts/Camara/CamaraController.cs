using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    // Variables privadas
    private GameObject jugadorGO;

    // Start is called before the first frame update
    void Start()
    {
        jugadorGO = GameObject.FindWithTag(Constantes.Tags.JUGADOR);
    }

    private void FixedUpdate()
    {
        TrasladarCamara();
    }

    // Esta funcion hace 2 cosas, por un lado elige la dirección hacia donde tiene que ir: si el player está dentro
    // de unos rangos, se mueve con él, si se sale de esos rangos, la cámara se queda al límite de esos rangos.
    // Después, calcula la dirección a la que tiene que ir y traslada la cámara hacia ese punto.
    private void TrasladarCamara()
    {
        float xDestino;

        if(jugadorGO.transform.position.x < Constantes.Camara.LIMITE_IZQ)
        {
            xDestino = Constantes.Camara.LIMITE_IZQ;
        }
        else if (jugadorGO.transform.position.x > Constantes.Camara.LIMITE_DER)
        {
            xDestino = Constantes.Camara.LIMITE_DER;
        }
        else
        {
            xDestino = jugadorGO.transform.position.x;
        }

        Vector3 dirDestino = new Vector3(xDestino, 0.0f);

        Vector3 dirNormalizada = Vector3.Normalize(dirDestino - this.transform.position);

        Vector2 dirSoloX = new Vector2(dirNormalizada.x, 0.0f);

        this.transform.Translate(dirSoloX * Constantes.Camara.VELOCIDAD * Time.fixedDeltaTime);
    }
}
