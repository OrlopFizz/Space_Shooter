using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public float MaxRadius = 1f;
    public float Interval = 5f;
    public GameObject ObjToSpawn = null;
    private Transform Origin = null;

    private void Awake()
    {
        Origin = GameObject.FindGameObjectWithTag("Player").transform; //sacar la posicion del jugador
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0f, Interval); //repetir el llamado de spawn empezando en el segundo 0 y repitiendose cada interval
    }

    void Spawn()
    {
        if(Origin == null) //si no existe el objeto jugador
        {
            return;
        }
        Vector3 SpawnPos = Origin.position + Random.onUnitSphere * MaxRadius; //generar un vector posicion
        SpawnPos = new Vector3(SpawnPos.x, 0f, SpawnPos.z);
        Instantiate(ObjToSpawn, SpawnPos, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
