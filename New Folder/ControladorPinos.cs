using UnityEngine;

public class ControladorPinos : MonoBehaviour
{
    public DetectarPinosCaidos detectorPinos;

    void Update()
    {
        if (detectorPinos != null)
        {
            // Ejemplo: mostrar en consola el total acumulado en tiempo real
            Debug.Log("Total actual de pinos ca�dos: " + detectorPinos.totalPinosCaidos);
        }
    }
}
