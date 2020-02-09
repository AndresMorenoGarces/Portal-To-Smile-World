using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSentences : MonoBehaviour
{
    private string[] stringArray;

    private void StringArray()
    {
        stringArray = new string[25]
        {
            "You're so bad player, but at least you aren´t losing. ", "Move that big heart and win. ",
            "You´re the champion... Of dummies. ", "You tripped on your laces, run. ",
            "You're so good; but, you're going last. Magnific. ", "Your father won´t come back, he's happy with their other family. But, Smile. ",
            "Your mother have a favourite child, but you aren't. ", "You were losing, but now you have been blessed, maybe you will win... or not. ",
            "What are you waiting for, son? Shake your brain, kid", "Why so quiet? Maybe, are you scared?, haha. ",
            "Are you crying because you are last? little insekt, you will be crushed. ", "You must know that I'm going to marry your dad. Now you will suffer. ",
            "You're lost in a wood with your uncle. Ruuuun. ", "Are you shure your girlfriend is not my metal brother? ",
            "You're down fall in my heart, don'worry... you're very ugly for everybody. ",  "Now the humanity're dead. Is lie. Only everybody hates you. ",
            "Is time to be loved. Everybody, except you. ", "I think you should win.",
            "I have your dad, Master tells me. Now you are also my slave of love.", "Only if you're good you can win. Is joke, everything is random. ",
            "Hey don't scare, only i want to say you that you're awesome baby. ", "Boom. Everybody is dead because you're amazing, hooney. ",
            "Please, tell your mother I can't love her. Do not bother me more. ", "If you continue like this, you must be really ugly. ", "Maybe I can help you, if you decide to sell your candy. "
        };
    }

    public void SendStringArray(string[] _stringArray)
    {
        _stringArray = stringArray;
    }
    private void Start()
    {
        StringArray();
    }
}
