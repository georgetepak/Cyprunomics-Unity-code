using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgoraAgiou : MonoBehaviour
{
    [SerializeField] AnimationClip clip;
    [SerializeField] Animation animAgoras;




    private void OnMouseDown()
    {
        
        animAgoras.clip = clip;
        animAgoras.Play();

    }





}
