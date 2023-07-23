using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounds_lock : MonoBehaviour
{
    public Rect level_bounds;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //
    void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, level_bounds.xMin, level_bounds.xMax),
            transform.position.y,
            Mathf.Clamp(transform.position.z, level_bounds.yMin, level_bounds.yMax));
    }

    private void OnDrawGizmosSelected()
    {
        const int cubeDepth = 1;
        Vector3 boundscenter = new Vector3(level_bounds.xMin + level_bounds.width*0.5f, 0,level_bounds.yMin + level_bounds.height*0.5f);
        Vector3 boundsheight = new Vector3(level_bounds.width, cubeDepth, level_bounds.height);
        Gizmos.DrawWireCube(boundscenter, boundsheight);
    }
}
