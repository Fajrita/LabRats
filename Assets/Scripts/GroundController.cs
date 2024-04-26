using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] float groundPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       collision.gameObject.transform.position = Vector3.Lerp(collision.gameObject.transform.position, new Vector3(collision.gameObject.transform.position.x, groundPosition,0),2);
    }

}
