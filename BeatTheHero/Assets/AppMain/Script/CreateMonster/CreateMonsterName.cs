using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// モンスターの名前入力欄
/// </summary>
public class CreateMonsterName : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] CharacterLibrary characterLibrary;

    public string nameKeep;

    public void InputText()
    {
        nameKeep = inputField.text;

    }
}

