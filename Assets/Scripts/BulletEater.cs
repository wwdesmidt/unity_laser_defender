using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEater : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);
    }
}
