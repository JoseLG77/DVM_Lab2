using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float velocidad = 50f;
    public float fuerzaSalto = 100f;
    public int maxSaltos = 2;
    int saltosRestantes;
    public float distanciaDeteccion = 1f;
    Rigidbody2D rb;
    bool enSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        saltosRestantes = maxSaltos;
    }

    void Update()
    {
        Mover();
        Saltar();
    }

    void Mover()
    {
        float movimiento = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(movimiento * velocidad, rb.linearVelocity.y);
    }

    void Saltar()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distanciaDeteccion);
        if (hit.collider != null && hit.collider.CompareTag("Suelo"))
        {
            enSuelo = true;
            saltosRestantes = maxSaltos; 
        }
        else
        {
            enSuelo = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            saltosRestantes--;
        }
    }
}