using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    //a variable to determine the door unlocking spped
    [SerializeField] private float unlockingSpeed = 2;
    // a variable unlocking time which is the time needed to unlock the door
    [SerializeField] private float unlockingTime = 3;
    // bool to check if the door is unlocked
    [SerializeField] private bool isDoorUnlocked = false;


    public void UnlockDoor()
    {
        isDoorUnlocked = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDoorUnlocked)
        {
            unlockingTime -= Time.deltaTime;
            transform.Translate(Vector3.down * Time.deltaTime * unlockingSpeed);

            if(unlockingTime <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
