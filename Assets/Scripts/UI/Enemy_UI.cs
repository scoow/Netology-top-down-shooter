using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_UI : Character_UI
{
    [SerializeField] private RectTransform _hpBarTransform;

    private void Update()
    {
        _hpBarTransform.LookAt(Camera.main.transform.position);
    }
}