using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bartender : Interactable
{
    public GameObject says;
    public GameObject text;
    private float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        says.SetActive(true);
        text.SetActive(false);
        StartCoroutine(DelayAndReset());
    }

    private IEnumerator DelayAndReset()
    {
        yield return new WaitForSecondsRealtime(timer);


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
