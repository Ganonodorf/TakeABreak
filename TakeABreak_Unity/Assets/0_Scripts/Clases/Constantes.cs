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
    }

    public class ObjetosInteractuables
    {
        public static readonly string ESPEJO_NOMBRE = "Espejo";
        public static readonly string ESPEJO_TEXTOAMOSTRAR = "Pulsa Q para mirarte al espejo";

        public static readonly string FOTO_NOMBRE = "Foto";
        public static readonly string FOTO_TEXTOAMOSTRAR = "Pulsa Q para ver la foto";

        public static readonly string TAZA_NOMBRE = "Taza";
        public static readonly string TAZA_TEXTOAMOSTRAR = "Pulsa Q para coger la taza";

        public static readonly string NPC_PRUEBA_NOMBRE = "Taza";
        public static readonly string NPC_PRUEBA_TEXTOAMOSTRAR = "Pulsa Q para hablar con este NPC";
        public static readonly string NPC_PRUEBA_PATH_SPRITE = "Assets/Sprites/Jugador/Jugador_Cabeza_Inversa.png";

        public static readonly string ESCALERAS_NOMBRE = "Escaleras";
        public static readonly string ESCALERAS_TEXTOAMOSTRAR = "Pulsa Q para subir las escaleras";
    }

    public class Jugador
    {
        public class Movimiento
        {
            public static readonly float VELOCIDAD = 0.25f;
        }

        public class Animacion
        {
            public static readonly string IDLE_ALANTE = "Jugador_Idle_Alante";
            public static readonly string IDLE_ATRAS = "Jugador_Idle_Atras";
            public static readonly string ANDANDO_ALANTE = "Jugador_Andando_Alante";
            public static readonly string ANDANDO_ATRAS = "Jugador_Andando_Atras";
        }
    }

    public class Camara
    {
        public static readonly float VELOCIDAD = 20.0f;
        public static readonly float LIMITE_IZQ = 0.0f;
        public static readonly float LIMITE_DER = 640.0f;
    }
}
