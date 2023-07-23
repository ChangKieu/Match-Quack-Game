using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theme : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
