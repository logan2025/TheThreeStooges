using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class DeathTilemap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("Player died");
            Destroy(collision.gameObject);
        }
    }
}
