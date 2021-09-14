using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour
{

    [SerializeField] private Material winningMaterial;
    [SerializeField] private GameObject winningUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Couroutine
    IEnumerator WinningRoutine()
    {
        GetComponent<MeshRenderer>().material = winningMaterial;
        //enable our winning UI gameobject (Canvas)
        winningUI.SetActive(true);
        //Set the time scale to 0.25f (slowmo mode)
        Time.timeScale = 0.25f;

        //wait for 1f, but note every second in reallife now is 0.25 in our game to this wait will be around 4 seconds
        yield return new WaitForSeconds(1f);

        Time.timeScale = 1f;

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(WinningRoutine());
        }
    }
}
