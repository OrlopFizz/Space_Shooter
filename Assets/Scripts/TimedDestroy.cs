using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    public float DestroyTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTime); //con esta linea se destruye el objeto al crearlo DESPUES del tiempo dado en DestroyTime
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
