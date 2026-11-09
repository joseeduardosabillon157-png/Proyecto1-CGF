using UnityEngine;

public class MovimientoFPS : MonoBehaviour
{
    public CharacterController controlador;
    public float velocidad = 6.0f;
    public float gravedad = -9.81f;
    public float alturaSalto = 1.5f;
    
    public Transform camara;
    public float sensibilidadMouse = 2.0f;
    private float rotacionX = 0f;

    private Vector3 velocidadVertical;
    private bool estaEnSuelo;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Detectar si el jugador está en el suelo
        estaEnSuelo = controlador.isGrounded;
        if (estaEnSuelo && velocidadVertical.y < 0)
        {
            velocidadVertical.y = -2f; // Mantiene al jugador pegado al piso
        }

        // Movimiento de la cámara con el mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        camara.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // Movimiento horizontal con W, A, S, D
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movimiento = transform.right * x + transform.forward * z;
        controlador.Move(movimiento * velocidad * Time.deltaTime);

        // Salto al presionar la barra espaciadora
        if (estaEnSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            velocidadVertical.y = Mathf.Sqrt(alturaSalto * -2f * gravedad);
        }

        // Aplicar la gravedad de forma acumulativa
        velocidadVertical.y += gravedad * Time.deltaTime;
        controlador.Move(velocidadVertical * Time.deltaTime);
    }
}