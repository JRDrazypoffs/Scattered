using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is a dialogue template
public class Dialogue
{
    [SerializeField] string ToddName;
    [SerializeField] string CharacterName;

    [TextArea(3, 10)]// Makes the text area larger by min and mx number of lines
    [SerializeField] string[] DialogLines;
}
