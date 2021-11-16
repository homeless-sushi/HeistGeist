using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private SpriteRenderer _laserRenderer;

    void Awake()
    {
        _laserRenderer = GetComponent<SpriteRenderer>();
        _laserRenderer.color = Color.clear;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Alarm");
        _laserRenderer.color = Color.white;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        _laserRenderer.color = Color.clear;
    }
    
    
}
