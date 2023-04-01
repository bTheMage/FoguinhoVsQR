using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float timeToLive = 1f;

    private void FixedUpdate() {
        timeToLive -= Time.fixedDeltaTime;
        if (0f >= timeToLive) Destroy(gameObject);
    }
}
