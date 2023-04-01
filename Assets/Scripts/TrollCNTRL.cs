using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TrollCNTRL : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    // Start is called before the first frame update
    void Awake() {
        speed *= 1f + Random.value;
    }

    void FixedUpdate() {
        Vector3 distance = PlayerCNTRL.playerPosition - transform.localPosition;
        Vector3 movement = Time.fixedDeltaTime * speed * distance.normalized;
        movement = (movement.magnitude > distance.magnitude) ? (distance) : (movement);
    
        transform.localPosition += movement;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Bullet") {
            die();
        } else if (other.gameObject.tag == "Player") {
            SceneManager.LoadScene("Main");
        }

        Debug.Log(gameObject.name + " collided with " + other.gameObject.tag);
    }

    void die () {
        Destroy(gameObject);
    }
}

