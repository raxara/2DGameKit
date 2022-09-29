using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremierScript : MonoBehaviour
{
    
    public float var1 = 15;

    public Test test1;

    public Test test2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class Test
{
    public int var2;

    public Test()
    {
        var2 = 4;
    }
}
