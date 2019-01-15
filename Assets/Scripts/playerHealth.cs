using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    [SerializeField] int Health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text heathText;
    
    private void Update()
    {
        heathText.text = Health.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        Health = Health - healthDecrease;
    }
}
