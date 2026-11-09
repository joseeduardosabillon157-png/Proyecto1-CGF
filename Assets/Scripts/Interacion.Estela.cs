using UnityEngine;

public class InteraccionEstela : MonoBehaviour
{
    public float distanciaInteraccion = 3f;
    public LayerMask capaInteractcable;
    private bool mostrandoInfo = false;
    private string textoEstela = "";

    void Update()
    {
        
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distanciaInteraccion))
        {
            
            if (hit.collider.CompareTag("Estela") || hit.collider.name.Contains("Estela") || hit.collider.name.Contains("Escalinata"))
            {
                mostrandoInfo = true;
                textoEstela = "Estructura histórica: " + hit.collider.name + "\nPresiona 'E' para leer la ficha histórica.";
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Mostrando información de: " + hit.collider.name);
                }
            }
            else
            {
                mostrandoInfo = false;
            }
        }
        else
        {
            mostrandoInfo = false;
        }
    }

    void OnGUI()
    {
        if (mostrandoInfo)
        {
            
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height - 100, 300, 50), textoEstela);
        }
    }
}