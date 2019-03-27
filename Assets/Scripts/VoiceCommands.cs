using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceCommands : MonoBehaviour {
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        actions.Add("up", Up);
        actions.Add("down", Down);
        actions.Add("left", Left);
        actions.Add("right", Right);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += SpeechRecognised;
    }

    private void SpeechRecognised(PhraseRecognizedEventArgs speech)
    {

    }
	
}
