using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ilumisoft.Collecticon;

public class CameraFollow : MonoBehaviour
{
    private Player player;
    private Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindObjectOfType<Player>() == null)
        {
            return;
        }
        player = GameObject.FindObjectOfType<Player>().GetComponent<Player>();
        distance = transform.position - player.transform.position;
    }

    // Update is called once per frame

    private void Update()
    {
        if(player!=null)
        {
            transform.position = distance + player.transform.position;
        }
    }
}
