using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JavascriptHook : MonoBehaviour
{
    [SerializeField] private SpriteRenderer circleSpriteRenderer;
    [SerializeField] private Text stringText;
    [SerializeField] private Text numText;

    public void TintRed()
    {
        circleSpriteRenderer.color = Color.red;
    }

    public void TintGreen()
    {
        circleSpriteRenderer.color = Color.green;
    }

    public void TestJson(string json)
    {
        JsonObject jsonObject = JsonUtility.FromJson<JsonObject>(json);
        stringText.text = $"Name: {jsonObject.name}; Age: {jsonObject.age}";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TintRed();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            TintGreen();
        }
    }

    public class JsonObject
    {
        public string name;
        public int age;
    }
}
