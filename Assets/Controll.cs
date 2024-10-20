using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controll : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость перемещения игрока
    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] AudioSource audioFather, audioEmporas, audioSardinia;

    [SerializeField] GameObject oblakoToShow, oblakoPateras, oblakoSardinia;
    [SerializeField] ChatController chatController;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (chatController.isChatOpen == true) return;

        // Получаем значения нажатий клавиш
        float moveX = Input.GetAxisRaw("Horizontal"); // Влево/Вправо (стрелки или A/D)
        float moveY = Input.GetAxisRaw("Vertical");   // Вверх/Вниз (стрелки или W/S)

        // Задаем направление движения
        movement = new Vector2(moveX, moveY).normalized;

        //CAMERA 
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -100);
    }

    void FixedUpdate()
    {
        // Перемещаем игрока с использованием Rigidbody2D
        rb.velocity = movement * moveSpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Emporas1"))
        {
            oblakoToShow.SetActive(true);
            audioEmporas.Play();
        }
        else if (collision.gameObject.CompareTag("Pateras"))
        {
            oblakoPateras.SetActive(true);
            audioFather.Play();
        }
        else if (collision.gameObject.CompareTag("Sardinia"))
        {
            oblakoSardinia.SetActive(true);
            audioSardinia.Play();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Emporas1"))
        {
            oblakoToShow.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Pateras"))
        {
            oblakoPateras.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Sardinia"))
        {
            oblakoSardinia.SetActive(false);
        }
    }


    public void goBuy()
    {
        SceneManager.LoadScene("GAME");
    }




}
