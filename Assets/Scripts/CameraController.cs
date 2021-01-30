using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float yOffset, zOffset;
    [SerializeField]
    [Range(0,1)]
    private float smoothFollow = .99f;
    [SerializeField]
    private Transform player;
    

    private void Awake()
    {
        this.transform.position = player.position;

    }

    private void LateUpdate()
    {
        float inverse = 1 - smoothFollow;
        float y;
        float x = ((smoothFollow * transform.position.x) + (inverse * player.position.x));
        if(Mathf.Abs(player.position.y + yOffset - transform.position.y) >= .5)
        {
            y = ((smoothFollow * transform.position.y) + (inverse * (player.position.y + yOffset)));
        }
        else
        {
             y = player.position.y + yOffset;
        }
        
        Vector3 targetPos = new Vector3(x, y, player.transform.position.z + zOffset);
        transform.position = targetPos;
        transform.LookAt(player);
    }

}
