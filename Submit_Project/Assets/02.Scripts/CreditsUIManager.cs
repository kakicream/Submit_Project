using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsUIManager : MonoBehaviour
{
    private GameObject instructionText;

    private void Awake()
    {
        instructionText = GameObject.Find("InstructionText");
    }

    private void Start()
    {
        StartCoroutine(TextOnInterval());
        instructionText.SetActive(true);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator TextOnInterval()
    {
        yield return new WaitForSeconds(3.0f);
    }
}
