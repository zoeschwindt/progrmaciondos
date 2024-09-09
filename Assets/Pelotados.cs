using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pelotados : MonoBehaviour
{
    public Vector2 velocidadInicial;
    private Rigidbody2D pelotitaRB;
    bool isMoving;
    public Scores sumarScores;


    // Start is called before the first frame update
    void Start()
    {
        pelotitaRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            pelotitaRB.velocity = velocidadInicial;
            isMoving = true;
        }
        Victory();

    }
    private void OnCollisionEnter2D(Collision2D choque)
    {
        if (choque.gameObject.CompareTag("Brick"))
        {
            sumarScores.Contador(3);
            Destroy(choque.gameObject);
        }
        if (choque.gameObject.CompareTag("Dead"))
        {
            GameOver();
        }
    }
    void Victory()
    {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");
        if (bricks.Length == 0)
        {
            SceneManager.LoadScene("Victoria");
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
