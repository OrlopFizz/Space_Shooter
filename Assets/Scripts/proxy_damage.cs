using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proxy_damage : MonoBehaviour
{
    public float damage_per_second = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        health h = other.gameObject.GetComponent<health>();
        if (h == null)
        {
            return;
        }
        h.HealthPoints -= damage_per_second * Time.deltaTime; //restarle a los health points por el tiempo entre frames
    }
}
