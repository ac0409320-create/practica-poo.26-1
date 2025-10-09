using UnityEngine;
using TMPro; // ?? Importante para usar TextMeshPro

public class DetectarPinosCaidos : MonoBehaviour
{
    public GameObject jugador;

    // Valor que se devuelve cuando el pino está caído
    public float cuandoElPinoEstaCaido = 10f;

    // Umbral de inclinación (en grados) para considerar que el pino está caído
    public float umbralCaida = 45f;

    // Referencias a los 10 pinos
    public GameObject pino1;
    public GameObject pino2;
    public GameObject pino3;
    public GameObject pino4;
    public GameObject pino5;
    public GameObject pino6;
    public GameObject pino7;
    public GameObject pino8;
    public GameObject pino9;
    public GameObject pino10;

    // ? Variable pública para sumar todos los pinos caídos
    public float totalPinosCaidos = 0f;

    // ? Referencia al texto TMP en pantalla
    public TMP_Text textoPinosCaidos;

    private GameObject[] pinos;
    private bool[] pinosCaidos;

    void Start()
    {
        pinos = new GameObject[]
        {
            pino1, pino2, pino3, pino4, pino5,
            pino6, pino7, pino8, pino9, pino10
        };

        pinosCaidos = new bool[pinos.Length];

        ActualizarTexto();
    }

    void Update()
    {
        for (int i = 0; i < pinos.Length; i++)
        {
            GameObject pino = pinos[i];
            if (pino != null && !pinosCaidos[i])
            {
                float angulo = Vector3.Angle(pino.transform.up, Vector3.up);

                if (angulo > umbralCaida)
                {
                    pinosCaidos[i] = true;
                    PinoCaido(pino);
                }
            }
        }
    }

    void PinoCaido(GameObject pino)
    {
        totalPinosCaidos += cuandoElPinoEstaCaido;
        ActualizarTexto();

        Debug.Log($"El pino {pino.name} se ha caído. Valor agregado: {cuandoElPinoEstaCaido} | Total: {totalPinosCaidos}");
    }

    void ActualizarTexto()
    {
        if (textoPinosCaidos != null)
        {
            textoPinosCaidos.text = $"Pinos Caídos: {totalPinosCaidos}";
        }
    }
}
