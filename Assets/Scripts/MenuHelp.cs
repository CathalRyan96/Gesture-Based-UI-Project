using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;


public class MenuHelp : MonoBehaviour
{
    [SerializeField]
    private string newLevel;
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        
        actions.Add("help", Help);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += SpeechRecognised;
        keywordRecognizer.Start();
    }

    private void SpeechRecognised(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();

    }

    
    private void Help()
    {
        SceneManager.LoadScene(newLevel);
    }

    /*private void Help()
    {
        SceneManager.LoadScene(newLevel);
    }*/


}
