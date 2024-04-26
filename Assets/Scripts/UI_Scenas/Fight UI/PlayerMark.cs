using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMark : MonoBehaviour
{
    GameObject rat;
    void Start()
    {
        rat = gameObject.transform.parent.GetChild(0).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        var size = rat.GetComponent<BoxCollider2D>().size.y;
        var offset = rat.GetComponent<BoxCollider2D>().offset.y;
        //Debug.Log(size);
        gameObject.transform.localPosition = new Vector2(0, (size/2 + offset) + 0.4f);


    }
}
