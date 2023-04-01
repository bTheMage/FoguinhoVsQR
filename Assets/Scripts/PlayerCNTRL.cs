using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DefaultExecutionOrder(-10)]
public class PlayerCNTRL : MonoBehaviour
{
    public static Vector3 playerPosition;

    [SerializeField] Transform cam;
    [SerializeField] Transform world;
    
    [SerializeField] float force = 1f;

    public bool zoomOut = false;
    Rigidbody2D rb;
    Vector3 move;

    // Start is called before the first frame update
    void Awake() {
        transform.localPosition = Vector3.zero;
        move = Vector3.zero;
        playerPosition = transform.localPosition;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Input.GetKeyUp("space")) zoomOut = !zoomOut;

        move = new Vector3(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"),
            0f
        );
    }

    private void FixedUpdate() {
        if (!zoomOut) {
            world.localScale = new Vector3(1f, 1f, 1f);
            cam.localPosition = new Vector3(
                transform.localPosition.x,
                transform.localPosition.y,
                -10f
            );
        } else {
            world.localScale = new Vector3(0.2f, 0.2f, 1f);
            cam.localPosition = new Vector3(0f, 0f, -10f);
        }

        transform.localPosition += Time.fixedDeltaTime * force * move;
        move *= 0.5f;
        playerPosition = transform.localPosition;
    }
}
