using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLevel3 : MonoBehaviour
{
    private int vida;
    private int vidaMaxima = 3;
    public static int morte = 4;

    public static bool playerMorreu = false;
    public static int encostou;


    public Transform myTransform;

    [Header("Vida")]
    [SerializeField] Image vidaOn;
    [SerializeField] Image vidaOff;

    [SerializeField] Image vidaOn2;
    [SerializeField] Image vidaOff2;

    [Header("Inimigos")]
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public AudioSource enemyDying;
    public AudioSource audioBoss;
    public AudioSource audioWin;

    public Rigidbody2D rb;
    public int moveSpeed;
    private float direction;

    private Vector3 facingRight;
    private Vector3 facingLeft;

    [Header("Player")]
    public bool taNoChao;
    public Transform detactaChao;
    public LayerMask oQueEhChao;
    public AudioSource pulo;

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
        encostou = 0;
        myTransform = transform;
        level3flyEnemy.health = 1;
        level3flyEnemy2.health = 1;
        level3inimigo.health = 1;
        Boss.health = 3;
        morte = 0;
        QuitDialogo.final = false;
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

        if (QuitDialogo.final == true && coletaItem.moeda == 12)
        {
            SceneManager.LoadScene("vocevenceu");

        }

        if (QuitDialogo.final == true && coletaItem.moeda != 12)
        {
            SceneManager.LoadScene("GameOverLevel3");

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
            SceneManager.LoadScene("GameOverLevel3");
        }

        if (other.CompareTag("Enemy") && level3flyEnemy.health != 0)
        {
            Dano();
        }

        if (other.CompareTag("Enemy2") && level3flyEnemy2.health != 0)
        {
            Dano();
        }

        if (other.CompareTag("Enemy3") && level3inimigo.health != 0)
        {
            Dano();
        }

        if (other.CompareTag("Enemy4") && Boss.health != 0)
        {
            Dano();
        }

        if (other.CompareTag("espinho"))
        {
            Dano();
        }

        if (other.CompareTag("deadlyEnemy"))
        {
            SceneManager.LoadScene("GameOverLevel3");
        }

        if (taNoChao == false && other.CompareTag("enemydead1"))
        {
            level3flyEnemy.health = 0;
            morte = 1;
            enemyDying.Play();
        }

        if (taNoChao == false && other.CompareTag("enemydead2"))
        {
            level3flyEnemy2.health = 0;
            morte = 2;
            enemyDying.Play();
        }

        if (taNoChao == false && other.CompareTag("enemydead3"))
        {
            level3inimigo.health = 0;
            morte = 3;
            enemyDying.Play();
        }

        if (other.CompareTag("somboss"))
        {
            audioBoss.Play();
            encostou = 1;

        }

        if (taNoChao == false && other.CompareTag("enemydead4"))
        {
            Boss.health--;

            if (Boss.health == 0)
            {
                morte = 4;
                enemyDying.Play();
                audioBoss.Stop();
                audioWin.Play();
            }
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
            SceneManager.LoadScene("GameOverLevel3");
            playerMorreu = true;
        }

    }
}


