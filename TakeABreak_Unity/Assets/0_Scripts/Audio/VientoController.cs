using System;
using System.Collections;
using UnityEngine;

public class VientoController : MonoBehaviour
{
    private AudioSource vientoAudioSource;
    private Coroutine vientoCoroutine;

    private float pasoViento = 0.01f;

    private void Awake()
    {
        vientoAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == Constantes.Tags.JUGADOR)
        {
            AtenuarViento();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == Constantes.Tags.JUGADOR)
        {
            DesatenuarViento();
        }
    }

    private void AtenuarViento()
    {
        if(vientoCoroutine != null)
        {
            StopCoroutine(vientoCoroutine);
        }

        vientoCoroutine = StartCoroutine(AtenuarVientoCoroutine());
    }

    private void DesatenuarViento()
    {
        if (vientoCoroutine != null)
        {
            StopCoroutine(vientoCoroutine);
        }

        vientoCoroutine = StartCoroutine(DesatenuarVientoCoroutine());
    }

    private IEnumerator AtenuarVientoCoroutine()
    {
        while (vientoAudioSource.volume > 0.0f)
        {
            vientoAudioSource.volume -= pasoViento;
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator DesatenuarVientoCoroutine()
    {
        while (vientoAudioSource.volume < 1.0f)
        {
            vientoAudioSource.volume += pasoViento;
            yield return new WaitForFixedUpdate();
        }
    }
}
