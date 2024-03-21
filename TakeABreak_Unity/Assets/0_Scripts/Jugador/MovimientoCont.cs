using System;
using UnityEngine;

public class MovimientoCont : MonoBehaviour
{
    // Variables privadas
    private bool mirandoAlante;

    public static event Action<EstadoMovimiento> OnMovimientoChanged;

    private void Start()
    {
        mirandoAlante = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetEstadoJuego() == EstadoJuego.Andando)
        {
            if(Input.GetAxis("Horizontal") > 0)
            {
                mirandoAlante = true;
                OnMovimientoChanged?.Invoke(EstadoMovimiento.AndandoAlante);
            }
            else if(Input.GetAxis("Horizontal") < 0)
            {
                mirandoAlante = false;
                OnMovimientoChanged?.Invoke(EstadoMovimiento.AndandoAtras);
            }
            else if(mirandoAlante == true)
            {
                OnMovimientoChanged?.Invoke(EstadoMovimiento.Idle_Alante);
            }
            else
            {
                OnMovimientoChanged?.Invoke(EstadoMovimiento.Idle_Atras);
            }
        }
    }

    private void FixedUpdate()
    {
        //this.transform.Translate(dirMovimiento * Constantes.Jugador.Movimiento.VELOCIDAD);
    }

    public void MovimientoAlante()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + 1,
                                                    gameObject.transform.position.y);
    }

    public void MovimientoAtras()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - 1,
                                                    gameObject.transform.position.y);
    }
}

public enum EstadoMovimiento
{
    Idle_Alante,
    Idle_Atras,
    AndandoAlante,
    AndandoAtras
}
