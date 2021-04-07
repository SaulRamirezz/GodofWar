using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableChest : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.GetComponent<Weapon>())
        {
            Destroy(gameObject);
        }
    }
}
