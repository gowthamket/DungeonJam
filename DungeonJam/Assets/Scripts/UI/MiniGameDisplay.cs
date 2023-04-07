using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGameDisplay : MonoBehaviour
{
    public MiniGameUIText info;
    public TextMeshProUGUI Instructions;
    public TextMeshProUGUI Name;


    private void Start()
    {
        Instructions.text = info.GameInstructions;
        Name.text = info.GameName;
    }




}
