using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �����X�^�[�̖��O���͗�
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

