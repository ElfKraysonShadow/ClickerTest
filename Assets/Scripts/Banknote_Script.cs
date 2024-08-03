using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banknote_Script : MonoBehaviour
{
    float pushForce = 9f;
    int rotation;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-2f, 2f), pushForce), ForceMode2D.Impulse);
        rotation = Random.Range(0, 2) == 0 ? -1 : 1;

    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(new Vector3(0f, 0f, rotation) * Random.Range(180f, 360f) * Time.deltaTime);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
