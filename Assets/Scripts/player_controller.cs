using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_controller : MonoBehaviour
{
    public bool MouseLook = true;
    public string horzaxis = "Horizontal";
    public string vertaxis = "Vertical";
    public string fireaxis = "Fire1";
    public float maxspeed = 5f;

    private Rigidbody thisBody = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //called once on creation
    void Awake()
    {
        thisBody = GetComponent<Rigidbody>();
    }

    //called a fixed number of times a second
    void FixedUpdate()
    {
        float horz = Input.GetAxis(horzaxis);
        float vert = Input.GetAxis(vertaxis);
        Vector3 move_direction = new Vector3(horz, 0.0f, vert);
        thisBody.AddForce(move_direction.normalized * maxspeed);
        thisBody.velocity = new Vector3(Mathf.Clamp(thisBody.velocity.x, -maxspeed, maxspeed),
            Mathf.Clamp(thisBody.velocity.y, -maxspeed, maxspeed),
            Mathf.Clamp(thisBody.velocity.z, -maxspeed, maxspeed));

        if (MouseLook)
        {
            Vector3 MousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f)); //saco la posicion del mouse en la pantalla y la convierto coordenadas en el mundo
            MousePosWorld = new Vector3(MousePosWorld.x, 0.0f, MousePosWorld.z); //quito la coordenada y
            Vector3 LookDirection = MousePosWorld - transform.position; //usando la resta, encuentro el vector que me lleva desde el vector del jugador hasta el vector posicion del mouse
            transform.localRotation = Quaternion.LookRotation(LookDirection.normalized); //uso lookrotation para sacar la rotacion local que me permite ver a la direccion que quiero 

            Debug.Log(transform.position);
            //Debug.Log("LookDirection: " + LookDirection.ToString() + " - MousePosWorld:" + MousePosWorld.ToString());
        }
    }
}
