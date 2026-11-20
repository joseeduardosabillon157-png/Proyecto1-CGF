using UnityEngine;

public class CambioCamara : MonoBehaviour
{
    public GameObject camaraFPS;
    public GameObject camaraAerea;
    private bool enAerea = false;

    void Start()
    {
        camaraFPS.SetActive(true);
        camaraAerea.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            enAerea = !enAerea;
            camaraFPS.SetActive(!enAerea);
            camaraAerea.SetActive(enAerea);
        }
    }
}