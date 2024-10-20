using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ChatController : MonoBehaviour
{
    public GameObject chatPanel, oblakoMessage, MessagesParent; // Панель чата
    public Button openChatButton; // Кнопка для открытия чата
    public TMP_InputField inputField; // Поле ввода текста
    public TextMeshProUGUI chatContent; // Текст, в котором будут отображаться сообщения
    public bool isChatOpen = false;
    [SerializeField] int botIndexMessage = 0;

    void Start()
    {
        // Скрываем чат по умолчанию
        chatPanel.SetActive(false);

        // Добавляем обработчик нажатия на кнопку
        openChatButton.onClick.AddListener(ToggleChat);
    }

    // Метод для открытия/закрытия чата
    void ToggleChat()
    {
        isChatOpen = !isChatOpen;
        chatPanel.SetActive(isChatOpen);

        // Если чат открылся, делаем InputField активным для ввода
        if (isChatOpen)
        {
            inputField.Select();
            inputField.ActivateInputField();
        }
    }

    void Update()
    {
        // Если нажата клавиша Enter и чат открыт
        if (isChatOpen && Input.GetKeyDown(KeyCode.Return))
        {
            SendMessage();
        }
    }

    // Метод отправки сообщения
    void SendMessage()
    {
        string playerMessage = inputField.text;

        if (!string.IsNullOrEmpty(playerMessage))
        {
            playerMessage = "<b>Question:</b> " + playerMessage;
            // Отображаем сообщение игрока
            StartCoroutine(generateMessage(playerMessage, true));

            // Очищаем поле ввода
            inputField.text = "";

            // Проверка на конкретные сообщения и ответ бота
            RespondToMessage(playerMessage);

            // Возвращаем фокус на поле ввода
            inputField.Select();
            inputField.ActivateInputField();
        }
    }

    // Метод ответа бота на сообщение
    void RespondToMessage(string playerMessage)
    {
        string botResponse = "";

        if(botIndexMessage == 0)
        {
            botResponse = "<b>Answer:</b> Οι άρχοντες της Σαρδηνίας λατρεύουν τα μυκηναϊκά αγγεία";
        }


        // Отображаем ответ бота
        StartCoroutine(generateMessage(botResponse, false));
    }



    IEnumerator generateMessage(string txt, bool isPlayer)
    {
        if (!isPlayer)
        {
            yield return new WaitForSeconds(3);
        }

        GameObject msg = Instantiate(oblakoMessage, new Vector2(0,0), Quaternion.identity);
        msg.transform.parent = MessagesParent.transform;
        msg.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = txt;
        
    }





    public void goSell()
    {
        SceneManager.LoadScene("Sell");
    }


}
