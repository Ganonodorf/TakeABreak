using UnityEngine;

internal interface IObjetoDialogable
{
    Sprite Sprite { get; set; }

    public void RespuestaDialogo(int codigoRespuesta);
}