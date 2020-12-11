using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AudioSource))]
public class SelectAI : MonoBehaviour
{
    [SerializeField] float Duration = .2f;

    [SerializeField] Vector3 scaleSize;
    [SerializeField] Vector3 defaultSize;

    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip audioClip;

    bool entered;
    float timer;
    float currentSpeed;
    NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        audio = GetComponent<AudioSource>();
        audio.playOnAwake = false;
        entered = true;
    }
    private void OnMouseEnter()
    {
        if (entered)
        {
            transform.DOScale(scaleSize, Duration).OnComplete(gg);
            entered = false;
            
            currentSpeed = navMeshAgent.speed;
            navMeshAgent.speed = 0f;
        }
    }
    public void StopMove()
    {
        navMeshAgent.enabled = false;
    }
    public void CanMove()
    {
        navMeshAgent.enabled = true;
    }
    private void Update()
    {       

        timer += Time.deltaTime;
        if(timer > 1)
        {
            entered = true;
            timer = 0;
        }
    }
    private void OnMouseExit()
    {
        transform.DOScale(defaultSize, Duration);
        navMeshAgent.speed = currentSpeed;
    }

    private void gg()
    {
        audio.PlayOneShot(audioClip);
    }
}
