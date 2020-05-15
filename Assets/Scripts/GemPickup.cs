using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickup : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //AudioSource.PlayClipAtPoint(pickupClip, transform.position);
            Destroy(this.gameObject);
        }

    }
}
