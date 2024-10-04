using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TextTyping : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBox;
    [SerializeField] bool startOnActive;
    [SerializeField] float typingDelay = 0.05f;

    private int currentVisibleCharacters;

    private void Start()
    {
        currentVisibleCharacters = 0;
        textBox.maxVisibleCharacters = 0;
        if(startOnActive) StartTyping();
    }

    //Slowly displays Text, as if someone was typing it out in real time

    IEnumerator TypingAnimation()
    {
        int MaxTextCharacters = textBox.text.Length;
        Observer.playSound("Typing");
        while (currentVisibleCharacters < MaxTextCharacters)
        {
            textBox.maxVisibleCharacters++;
            currentVisibleCharacters++;
            yield return new WaitForSeconds(typingDelay);
        }
        Observer.pauseSound("Typing");
    }

    void StartTyping()
    {
        StopAllCoroutines();
        StartCoroutine(TypingAnimation());
    }
}
