using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLevel2 : MonoBehaviour
{
    private int vida;
    private int vidaMaxima = 3;
    public static int morte = 4;

    public Transform myTransform;

    [SerializeField] Image vidaOn;
    [SerializeField] Image vidaOff;

    [SerializeField] Image vidaOn2;
    [SerializeField] Image vidaOff2;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public AudioSource enemyDying;

    public AudioSource pulo;

    public Rigidbody2D rb;
    public int moveSpeed;
    private float direction;

    private Vector3 facingRight;
    private Vector3 facingLeft;

    public bool taNoChao;
    public Transform detactaChao;
    public LayerMask oQueEhChao;

    public int pulosExtras = 1;

    private bool isPaused;

    [Header("Paineis e Menus")]
    public GameObject pausePanel;

    void Start()
    {
        Time.timeScale = 1f;
        vida = vidaMaxima;
        facingLeft = transform.localScale;
        facingRight = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        facingRight.x = facingRight.x * -1;
        myTransform = transform;
        level2flyEnemy.health = 1;
        level2flyEnemy2.health = 1;
        level2inimigo.health = 1;
        morte = 0;
    }

    void Update()
    {
        if (!isPaused)
        {

            taNoChao = Physics2D.OverlapCircle(detactaChao.position, 0.2f, oQueEhChao);

            if (Input.GetButtonDown("Jump") && taNoChao == true)
            {
                rb.velocity = Vector2.up * 5;
                pulo.Play();
            }
            if (Input.GetButtonDown("Jump") && taNoChao == false && pulosExtras > 0)
            {
                rb.velocity = Vector2.up * 5;
                pulosExtras--;
                pulo.Play();
            }
            if (taNoChao)
            {
                pulosExtras = 1;
            }

            direction = Input.GetAxis("Horizontal");

            if (direction > 0)
            {
                //olhando para a direita
                transform.localScale = facingRight;
            }
            if (direction < 0)
            {
                //olhando para a direita
                transform.localScale = facingLeft;
            }

            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        }

        if (Input.GetButtonDown("Pause"))
        {
            PauseScreen();
        }
    }

    void PauseScreen()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("gameOverArea"))
        {
            SceneManager.LoadScene("GameOverLevel2");
        }

        if (coletaItem.moeda == 31 && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Level2Win");
        }

        if (coletaItem.moeda != 31 && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene("GameOverLevel2");
        }

        if (other.CompareTag("Enemy") && level2flyEnemy.health != 0)
        {
            Dano();
        }

        if (other.CompareTag("Enemy2") && level2flyEnemy2.health != 0)
        {
            Dano();
        }

        if (other.CompareTag("Enemy3") && level2flyEnemy2.health != 0)
        {
            Dano();
        }

        if (other.CompareTag("deadlyEnemy"))
        {
            SceneManager.LoadScene("GameOverLevel2");
        }

        if (taNoChao == false && other.CompareTag("enemydead1"))
        {
            level2flyEnemy.health = 0;
            morte = 1;
            enemyDying.Play();
        }

        if (taNoChao == false && other.CompareTag("enemydead2"))
        {
            level2flyEnemy2.health = 0;
            morte = 2;
            enemyDying.Play();
        }

        if (taNoChao == false && other.CompareTag("enemydead3"))
        {
            level2inimigo.health = 0;
            morte = 3;
            enemyDying.Play();
        }

    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingPlatform")
        {
            myTransform.parent = collision.transform;
        }
    }
    public virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingPlatform")
        {
            myTransform.parent = null;
        }

    }

    private void Dano()
    {
        vida -= 1;

        if (vida == 2)
        {
            vidaOn2.enabled = true;
            vidaOff2.enabled = false;
        }
        else
        {
            vidaOn2.enabled = false;
            vidaOff2.enabled = true;
        }

        if (vida == 1)
        {
            vidaOn2.enabled = true;
            vidaOff2.enabled = false;

            vidaOn.enabled = true;
            vidaOff.enabled = false;
        }
        else
        {
            vidaOn.enabled = false;
            vidaOff.enabled = true;
        }

        if (vida <= 0)
        {
            SceneManager.LoadScene("GameOverLevel2");
        }

    }
}


