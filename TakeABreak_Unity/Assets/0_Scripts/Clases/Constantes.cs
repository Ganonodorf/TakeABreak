using UnityEngine;

public class Constantes
{
    public class Dialogos
    {
        public static readonly int FIN_CONVERSACION = -1;
        public static readonly int DISTANCIA_BOTONES = 11;
    }

    public class Tags
    {
        public static readonly string INTERACTUABLE = "Interactuable";
        public static readonly string BOCADILLO = "Bocadillo";
        public static readonly string BOCADILLO_ACCION = "BocadilloAccion";
        public static readonly string SPRITE_JUGADOR = "SpriteJugador";
        public static readonly string SPRITE_NPC = "SpriteNPC";
        public static readonly string PANEL_OPCIONES = "PanelOpciones";
        public static readonly string JUGADOR = "Player";
        public static readonly string CAMARA = "MainCamera";
        public static readonly string CASA = "Casa";
        public static readonly string MAR = "Mar";
    }

    public class ObjetosInteractuables
    {
        public static readonly string ESPEJO_NOMBRE = "Espejo";
        public static readonly string ESPEJO_TEXTOAMOSTRAR = "Pulsa Q para mirarte al espejo";

        public static readonly string FOTO_NOMBRE = "Foto";
        public static readonly string FOTO_TEXTOAMOSTRAR = "Pulsa Q para ver la foto";

        public static readonly string TAZA_NOMBRE = "Taza";
        public static readonly string TAZA_TEXTOAMOSTRAR = "Pulsa Q para coger la taza";

        public static readonly string NPC_PRUEBA_NOMBRE = "NPC";
        public static readonly string NPC_PRUEBA_TEXTOAMOSTRAR = "Pulsa Q para hablar con este NPC";
        public static readonly string NPC_PRUEBA_PATH_SPRITE = "Assets/Sprites/Jugador/Jugador_Cabeza_Inversa.png";

        public static readonly string ESCALERAS_NOMBRE = "Escaleras";
        public static readonly string ESCALERAS_ABAJO_TEXTOAMOSTRAR = "Pulsa Q para subir las escaleras";
        public static readonly string ESCALERAS_ARRIBA_TEXTOAMOSTRAR = "Pulsa Q para bajar las escaleras";

        public static readonly string SILLON_NOMBRE = "Sillon";
        public static readonly string SILLON_TEXTOAMOSTRAR = "Pulsa Q para sentarte en el sillón";
    }

    public class Animacion
    {
        public class Jugador
        {
            public static readonly string IDLE_ESPALDA = "Jugador_Idle_Espalda";
            public static readonly string GIRANDOSE = "Jugador_Girandose";
            public static readonly string IDLE_ALANTE = "Jugador_Idle_Alante";
            public static readonly string IDLE_ATRAS = "Jugador_Idle_Atras";
            public static readonly string ANDANDO_ALANTE = "Jugador_Andando_Alante";
            public static readonly string ANDANDO_ATRAS = "Jugador_Andando_Atras";
            public static readonly string NADA = "Jugador_Nada";
        }

        public class Escaleras
        {
            public static readonly string SUBIENDO_ESCALERAS_DER = "Subiendo_Escaleras_Der";
            public static readonly string BAJANDO_ESCALERAS_DER = "Bajando_Escaleras_Der";
            public static readonly string SUBIENDO_ESCALERAS_IZQ = "Subiendo_Escaleras_Izq";
            public static readonly string BAJANDO_ESCALERAS_IZQ = "Bajando_Escaleras_Izq";

            public static readonly float DURACION_ESCALERAS = 2.4f;
        }

        public class Sillon
        {

            public static readonly string SENTANDOSE_SILLON = "Sentandose_Sillon";
            public static readonly string LEVANTANDOSE_SILLON = "Levantandose_Sillon";

            public static readonly string MEDITANDO = "Meditando";
            public static readonly string MEDITANDO_INHALAR = "Meditando_Inhalar";
            public static readonly string MEDITANDO_EXHALAR = "Meditando_Exhalar";

            public static readonly string QUIETO = "Quieto";

            public static readonly float DURACION_SENTANDOSE_SILLON = 5.2f;
            public static readonly float DURACION_LEVANTANDOSE_SILLON = 3.2f;
        }

        public class Mar
        {
            public static readonly string IDLE = "Mar";
            public static readonly string INHALAR = "MarInhalar";
            public static readonly string EXHALAR = "MarExhalar";
            public static readonly string QUIETO = "MarQuieto";
        }

        public class Reflejo
        {
            public static readonly string IDLE_ESPALDAS_ALANTE = "Jugador_idle_espaldas";
            public static readonly string IDLE_ESPALDAS_ATRAS = "Jugador_idle_espaldas_atras";
            public static readonly string ANDANDO_ESPALDAS_ALANTE = "Jugador_andando_espaldas";
            public static readonly string ANDANDO_ESPALDAS_ATRAS = "Jugador_andando_espaldas_atras";
            public static readonly string NADA = "Nada";
        }
    }

    public class PosicionesClave
    {
        public static readonly float PosXInicial = -30.0f;

        public static readonly float PosYDentroDeCasa = -28.0f;
        public static readonly float PosYFueraDeCasa = -37.0f;

        public static readonly float PosLimiteArribaEscalerasIzq = 143.0f;
        public static readonly float PosLimiteAbajoEscalerasIzq = 122.0f;
        public static readonly Vector2 ArribaBajandoEscalerasIzq = new Vector2(144.0f, PosYDentroDeCasa);
        public static readonly Vector2 AbajoBajandoEscalerasIzq = new Vector2(116.0f, PosYFueraDeCasa);
        public static readonly Vector2 ArribaSubiendoEscalerasIzq = new Vector2(148.0f, PosYDentroDeCasa);
        public static readonly Vector2 AbajoSubiendoEscalerasIzq = new Vector2(121.0f, PosYFueraDeCasa);


        public static readonly float PosLimiteArribaEscalerasDer = 613.0f;
        public static readonly float PosLimiteAbajoEscalerasDer = 635.0f;
        public static readonly Vector2 ArribaBajandoEscalerasDer = new Vector2(612.0f, PosYDentroDeCasa);
        public static readonly Vector2 AbajoBajandoEscalerasDer = new Vector2(640.0f, PosYFueraDeCasa);
        public static readonly Vector2 ArribaSubiendoEscalerasDer = new Vector2(609.0f, PosYDentroDeCasa);
        public static readonly Vector2 AbajoSubiendoEscalerasDer = new Vector2(636.0f, PosYFueraDeCasa);


        public static readonly Vector2 Sillon = new Vector2(315.0f, PosYDentroDeCasa);
    }

    public class Camara
    {
        public static readonly float VELOCIDAD = 20.0f; // El original son 20
        public static readonly float LIMITE_IZQ = 0.0f;
        public static readonly float LIMITE_DER = 640.0f;

        public static readonly float DIRECCION_ESCALERAS = 0.6f;

        public static readonly float POSICION_MEDITANDO = 388.0f;
    }
}
