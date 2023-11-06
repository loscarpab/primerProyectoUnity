using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cadBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direccion;
    private Vector2 normalDebug;

    // Start is called before the first frame update
    void Start()
    {
        normalDebug = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + speed * Time.deltaTime * direccion;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Calcula la dirección de la normal de la colisión
        Vector2 normal = collision.ClosestPoint(transform.position) - (Vector2)transform.position;

        Debug.DrawRay(transform.position, normal, Color.red, 1000f);
        Debug.DrawRay(transform.position, direccion, Color.black, 1000f);
           
        // Refleja la dirección en función de la normal de la colisión
        direccion = Vector3.Reflect(direccion.normalized, normal.normalized);
        Debug.DrawRay(transform.position, direccion, Color.cyan, 1000f);
    }

}
