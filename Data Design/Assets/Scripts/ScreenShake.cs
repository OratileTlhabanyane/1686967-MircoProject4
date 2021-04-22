using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public Animator cameraShakeAnim;
     
    public void cameraShake ()
    {
        cameraShakeAnim.SetTrigger("ScreenShake");
    }
}
