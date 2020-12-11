using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUi : MonoBehaviour
{
    [SerializeField]  float Duration = 1f;
    RectTransform tran;
    private void Start()
    {
        tran = GetComponent<RectTransform>();
        tran.DOScale(new Vector3(1, 1, 1), Duration);
    }
}
