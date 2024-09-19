using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    // Variables privadas
    private GameObject jugadorGO;
    private EstadoCamara estadoCamaraActual;

    private void Awake()
    {
        MovimientoCont.OnMovimientoChanged += MovimientoCont_OnMovimientoChanged;
    }

    // Start is called before the first frame update
    void Start()
    {
        jugadorGO = GameObject.FindWithTag(Constantes.Tags.JUGADOR);
    }

    private void FixedUpdate()
    {
        TrasladarCamaraV2();
    }
    private void TrasladarCamaraV2()
    {
        Vector2 dirSoloX;

        if (estadoCamaraActual == EstadoCamara.MovDerecha)
        {
            dirSoloX = new Vector2(Constantes.Camara.DIRECCION_ESCALERAS, 0.0f);
        }

        else if (estadoCamaraActual == EstadoCamara.MovIzquierda)
        {
            dirSoloX = new Vector2(-Constantes.Camara.DIRECCION_ESCALERAS, 0.0f);
        }

        else if (estadoCamaraActual == EstadoCamara.EstaticaMeditando)
        {
            Vector3 dirDestino = new Vector3(Constantes.Camara.POSICION_MEDITANDO, 0.0f);

            Vector3 dirNormalizada = Vector3.Normalize(dirDestino - this.transform.position);

            dirSoloX = new Vector2(dirNormalizada.x, 0.0f);
        }

        else
        {
            float xDestino;

            if (jugadorGO.transform.position.x < Constantes.Camara.LIMITE_IZQ)
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

            Vector2 velocidad = Vector2.zero;

            Vector2 destino = new Vector2(xDestino, transform.position.y);

            transform.position = Vector2.SmoothDamp(transform.position, destino, ref velocidad, 0.1f);

            return;
        }

        this.transform.Translate(dirSoloX * Constantes.Camara.VELOCIDAD * Time.fixedDeltaTime);
    }

    // Esta funcion hace 2 cosas, por un lado elige la dirección hacia donde tiene que ir: si el player está dentro
    // de unos rangos, se mueve con él, si se sale de esos rangos, la cámara se queda al límite de esos rangos.
    // Después, calcula la dirección a la que tiene que ir y traslada la cámara hacia ese punto.
    private void TrasladarCamara()
    {
        Vector2 dirSoloX;

        if (estadoCamaraActual == EstadoCamara.MovDerecha)
        {
            dirSoloX = new Vector2(Constantes.Camara.DIRECCION_ESCALERAS, 0.0f);
        }

        else if (estadoCamaraActual == EstadoCamara.MovIzquierda)
        {
            dirSoloX = new Vector2(-Constantes.Camara.DIRECCION_ESCALERAS, 0.0f);
        }

        else if (estadoCamaraActual == EstadoCamara.EstaticaMeditando)
        {
            Vector3 dirDestino = new Vector3(Constantes.Camara.POSICION_MEDITANDO, 0.0f);

            Vector3 dirNormalizada = Vector3.Normalize(dirDestino - this.transform.position);

            dirSoloX = new Vector2(dirNormalizada.x, 0.0f);
        }

        else
        {
            float xDestino;

            if (jugadorGO.transform.position.x < Constantes.Camara.LIMITE_IZQ)
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

            dirSoloX = new Vector2(dirNormalizada.x, 0.0f);
        }

        this.transform.Translate(dirSoloX * Constantes.Camara.VELOCIDAD * Time.fixedDeltaTime);
    }

    private void MovimientoCont_OnMovimientoChanged(EstadoMovimiento nuevoEstadoMovimiento)
    {
        switch (nuevoEstadoMovimiento)
        {
            case EstadoMovimiento.SubiendoEscIzq:
                estadoCamaraActual = EstadoCamara.MovDerecha;
                break;
            case EstadoMovimiento.BajandoEscIzq:
                estadoCamaraActual = EstadoCamara.MovIzquierda;
                break;
            case EstadoMovimiento.SubiendoEscDer:
                estadoCamaraActual = EstadoCamara.MovIzquierda;
                break;
            case EstadoMovimiento.BajandoEscDer:
                estadoCamaraActual = EstadoCamara.MovDerecha;
                break;
            case EstadoMovimiento.Meditando:
                estadoCamaraActual = EstadoCamara.EstaticaMeditando;
                break;
            default:
                estadoCamaraActual = EstadoCamara.Persiguiendo;
                break;
        }
    }
}

enum EstadoCamara
{
    Persiguiendo,
    MovDerecha,
    MovIzquierda,
    EstaticaMeditando
}
