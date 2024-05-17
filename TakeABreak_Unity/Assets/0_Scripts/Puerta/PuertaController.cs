using System;
using UnityEngine;

public class PuertaController : MonoBehaviour
{
    GameObject jugadorGO;
    SpriteRenderer[] puertaSprites;
    float posXInicialJugador;
    float posXCollider;
    float offset;
    float longitudXCollider;
    bool fadeOut;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constantes.Tags.JUGADOR)
        {
            jugadorGO = collision.gameObject;
            posXInicialJugador = collision.transform.position.x;
            fadeOut = posXCollider > posXInicialJugador ? true : false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constantes.Tags.JUGADOR)
        {
            ActualizarColorSprite();
            jugadorGO = null;
            posXInicialJugador = 0.0f;
        }
    }

    private void Start()
    {
        InicializarVariables();
    }

    private void Update()
    {
        if(jugadorGO != null)
        {
            ActualizarColorSprite();
        }
    }

    private void ActualizarColorSprite()
    {
        float nuevaAlfa = CalcularNuevaAlfaV2();

        foreach(var sprite in puertaSprites)
        {
            sprite.color = new Color(sprite.color.r,
                                     sprite.color.g,
                                     sprite.color.b,
                                     nuevaAlfa);
        }
    }

    private float CalcularNuevaAlfaV2()
    {
        float restaPosiciones;

        if(jugadorGO.transform.position.x > (posXCollider - offset) && jugadorGO.transform.position.x < (posXCollider + offset))
        {
            restaPosiciones = 0.0f;
        }
        else
        {
            restaPosiciones = jugadorGO.transform.position.x < posXCollider ? posXCollider - offset - jugadorGO.transform.position.x :
                                                                              jugadorGO.transform.position.x - offset - posXCollider;
        }

        float nuevaAlfa = restaPosiciones / ((longitudXCollider / 2) - offset);

        return nuevaAlfa;
    }

    private float CalcularNuevaAlfa()
    {
        float restaPosiciones = jugadorGO.transform.position.x - posXInicialJugador;

        float nuevaAlfa = fadeOut ? 1.0f - (restaPosiciones / longitudXCollider) :
                                   -1.0f * (restaPosiciones / longitudXCollider);

        return nuevaAlfa;
    }

    private void InicializarVariables()
    {
        puertaSprites = GetComponentsInChildren<SpriteRenderer>();
        posXCollider = GetComponent<BoxCollider2D>().transform.position.x;
        longitudXCollider = GetComponent<BoxCollider2D>().size.x;
        offset = 6.0f;
    }
}
