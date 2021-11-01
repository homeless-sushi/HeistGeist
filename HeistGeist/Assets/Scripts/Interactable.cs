using System;
using Player;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour
{
    [SerializeField] private UnityEvent onInteract;
    [SerializeField] protected Sprite icon;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().InteractEvent.AddListener(OnInteract);
            other.GetComponent<IconOverHead>().SetIconOverHead(icon);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().InteractEvent.RemoveListener(OnInteract);
            other.GetComponent<IconOverHead>().SetIconOverHead(null);
        }
    }

    protected void OnInteract()
    {
        onInteract.Invoke();
    }
}