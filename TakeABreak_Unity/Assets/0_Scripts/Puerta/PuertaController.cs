using System;
using UnityEngine;

public class PuertaController : MonoBehaviour
{
    GameObject jugadorGO;
    SpriteRenderer[] puertaSprites;
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
        float nuevaAlfa = CalcularNuevaAlfa();

        foreach(var sprite in puertaSprites)
        {
            sprite.color = new Color(sprite.color.r,
                                     sprite.color.g,
                                     sprite.color.b,
                                     nuevaAlfa);
        }
    }

    private float CalcularNuevaAlfa()
    {
        float restaPosiciones = jugadorGO.transform.position.x - posXInicial;

        float nuevaAlfa = fadeOut ? 1.0f - (restaPosiciones / longitudXCollider) :
                                   -1.0f * (restaPosiciones / longitudXCollider);

        return nuevaAlfa;
    }

    private void InicializarVariables()
    {
        puertaSprites = GetComponentsInChildren<SpriteRenderer>();
        posXCollider = GetComponent<BoxCollider2D>().transform.position.x;
        longitudXCollider = GetComponent<BoxCollider2D>().size.x;
    }
}
