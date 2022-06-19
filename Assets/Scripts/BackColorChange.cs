using System;
using UnityEngine;
using UnityEngine.UI;

public class BackColorChange : MonoBehaviour
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        _image.color = Color.Lerp(Color.yellow, Color.cyan, Mathf.PingPong(Time.time, 1));
    }
}
