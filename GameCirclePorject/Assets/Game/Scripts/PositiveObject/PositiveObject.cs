using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositiveObject : MonoBehaviour,ICollactable
{
    public void DoCollect()
    {
        GameManager.Instance.Player.PlayerStatusAmount += 5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
