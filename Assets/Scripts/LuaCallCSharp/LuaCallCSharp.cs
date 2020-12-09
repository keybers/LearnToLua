using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region  Lesson1_CallClass

public class Test
{
    public void Speak(string str)
    {
        Debug.Log("Test:" + str);
    }
}

//命名空间也要加入进去
namespace MyTest{
    public class Test2
    {
        public void Speak(string str)
        {
            Debug.Log("Test:" + str);
        }
    }
}

#endregion
public class LuaCallCSharp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
