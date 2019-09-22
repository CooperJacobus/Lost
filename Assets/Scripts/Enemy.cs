using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playerTransform;
    private Rigidbody2D rb;
    public GameObject player;
    public float vx = 0;
    public float vy = 0;
    [SerializeField]
    public float x; //GET MY X POSITION
    [SerializeField]
    public float y; //GET MY Y POSITION
    [SerializeField]
    public float playerX;
    [SerializeField]
    public float playerY;
    Player playerScript;
    void Start()
    {
        playerScript = player.GetComponent<Player>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        x = this.transform.position.x;
        y = this.transform.position.y;
        Debug.Log($"The other player's x {playerScript.transform.position.x}");
        Debug.Log($"The other player's y {playerScript.transform.position.y}");
        Debug.Log($"My x position {x}");
        Debug.Log($"My y position {y}");
    }

    void Movement()
    {
      //Transform by vx
      this.transform.Translate( vx * Time.deltaTime * Vector3.right);
      //transform by vy
      this.transform.Translate(vy * Time.deltaTime * Vector3.up);
      

      //dampen velocities (compound legacy sytle)
      vx *= 0.999; //calibrate for framerate later
      vy *= 0.999; //calibrate for framerate later

      //accelerate towards player (binary style)
      vx += (playerX >= x) ? 0.1 : -0.1; //calibrate for framerate later
      vy += (playerY >= y) ? 0.1 : -0.1; //calibrate for framerate later
    }

}
