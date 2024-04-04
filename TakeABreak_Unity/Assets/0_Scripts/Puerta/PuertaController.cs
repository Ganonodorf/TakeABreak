using System;
using UnityEngine;

public class PuertaController : MonoBehaviour
{
    GameObject jugadorGO;
    SpriteRenderer puertaSprite;
    float posXInicial;
    float posXCollider;
    float longitudXCollider;
    bool fadeOut;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constantes.Tags.JUGADOR)
        {
            jugadorGO = collision.gameObject;
            posXInicial = collision.transform.position.x;
            fadeOut = posXCollider > posXInicial ? true : false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constantes.Tags.JUGADOR)
        {
            jugadorGO = null;
            posXInicial = 0.0f;
        }
    }

    private void Start()
    {
        puertaSprite = GetComponent<SpriteRenderer>();
        posXCollider = GetComponent<BoxCollider2D>().transform.position.x;
        longitudXCollider = GetComponent<BoxCollider2D>().size.x;
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
        Debug.Log("posXInicial: " + posXInicial);
        Debug.Log("jugadorGO.transform.position.x: " + jugadorGO.transform.position.x);
        puertaSprite.color = new Color(puertaSprite.color.r,
                                       puertaSprite.color.g,
                                       puertaSprite.color.b,
                                       CalcularNuevaAlfa());
        Debug.Log("Color sprite: " + puertaSprite.color);
    }

    private float CalcularNuevaAlfa()
    {
        float restaPosiciones = jugadorGO.transform.position.x - posXInicial;
        float nuevaAlfa;

        if(fadeOut)
        {
            nuevaAlfa = 1.0f - (restaPosiciones / longitudXCollider);
        }
        else
        {
            nuevaAlfa = -1.0f * (restaPosiciones / longitudXCollider);
        }

        return nuevaAlfa;
    }
}
