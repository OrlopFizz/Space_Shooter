using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFace : MonoBehaviour
{
    public Transform objToFollow = null;
    public bool FollowPlayer = false;

    private void Awake()
    {
        if (!FollowPlayer)//no seguir al jugador
        {
            return;
        }
        GameObject playerobj = GameObject.FindGameObjectWithTag("Player"); //buscar el objeto del jugador
        if (playerobj != null) { objToFollow = playerobj.transform; } //saco la informacion de la posicion del jugador

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(objToFollow == null) { return; } //si no estamos siguiendo al jugador
        Vector3 DirToObj = objToFollow.position - transform.position; //saco el vector que va del objeto jugador al enemigo
        if(DirToObj != Vector3.zero)
        {
            transform.localRotation = Quaternion.LookRotation(DirToObj.normalized, Vector3.up); //roto hacia el jugador
        }
    }
}
