using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SceneChangeManager : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess() 
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("InGame");
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone) {
            yield return null;

            if(op.progress < 0.9f) {
                progressBar.value = op.progress;
            }
            else {
                timer += Time.unscaledDeltaTime;
                progressBar.value = Mathf.Lerp(0.9f, 1f, timer);
                if(progressBar.value >= 1f) {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }

        }
        
        
    }
    
}