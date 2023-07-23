using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public GameObject DeathParticlesPrefab = null;
    public bool shouldDestroyOnDeath = true;
    [SerializeField] private float health_points = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) { HealthPoints = 0; }
    }

    //c# properties
    //estos son unas propiedades de c# que crear una interfaz para cambiar una variable
    //tipo getters y setters
    public float HealthPoints
    {
        get { return health_points; }
        set { health_points = value;
            if(health_points <= 0) //esto se agrega aca ya que solo tiene sentido verificar si se murio cuando hay cambios
            {
                //esta funcion llama a cualquier funcion que se llame "Die" en cualquier script ligado al objeto.
                //esto evita tener tipos y permite llamar funcion sin importar el tipo, el unico problema es que es un poco lento.
                SendMessage("Die", SendMessageOptions.DontRequireReceiver); 
                if (DeathParticlesPrefab != null)
                {
                    Instantiate(DeathParticlesPrefab, transform.position, transform.rotation);
                    
                }
                if (shouldDestroyOnDeath)
                {
                    Destroy(gameObject);
                }
            }
                                    }
    }
}
