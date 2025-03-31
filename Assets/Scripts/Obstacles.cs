using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public Transform puntoB;
    public float velocidad = 2f;

    Vector3 puntoA;
    bool yendoAPuntoB = true;

    void Start()
    {
        puntoA = transform.position;
    }

    void Update()
    {
        if (yendoAPuntoB)
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoB.position, velocidad * Time.deltaTime);
            if (Vector3.Distance(transform.position, puntoB.position) < 0.1f)
            {
                yendoAPuntoB = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoA, velocidad * Time.deltaTime);
            if (Vector3.Distance(transform.position, puntoA) < 0.1f)
            {
                yendoAPuntoB = true;
            }
        }
    }
}
