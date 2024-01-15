using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex : MonoBehaviour

{
    [SerializeField] private float parallexSpeed;

    private float startHeight;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        startHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        transform.Translate(Vector3.down * parallexSpeed * Time.deltaTime);

        if(transform.position.y < startPos.y - startHeight)
        {
            transform.position = startPos;
        }
    }
}
