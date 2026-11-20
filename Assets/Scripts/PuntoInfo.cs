using UnityEngine;
using TMPro;

public class PuntoInfo : MonoBehaviour
{
    public GameObject panelInfo;
    public TextMeshProUGUI textoInfo;
    [TextArea] public string mensaje;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelInfo.SetActive(true);
            textoInfo.text = mensaje;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelInfo.SetActive(false);
        }
    }
}