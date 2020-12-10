using System;
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

#region  Lesson2_ClassEnum

public enum testEnum{
    Idle,
    Walk,
    Attack,

}

#endregion

#region  Lesson3_CallArray List Dictionary

public class Lesson3
{
    public int[] array = new int[5]{1,2,3,4,5};

    public List<int> testList = new List<int>();

    public Dictionary<int,string> testDic = new Dictionary<int, string>();
}

#endregion

#region  Lesson4_CallFunction

public static class Tools
{
    public static void Move(this Lesson4 obj)
    {
        Debug.Log(obj.name + "移动");
    }
}
public class Lesson4
{
    public string name = "keyber";
    public void Speak(string str)
    {
        Debug.Log(str);
    }

    public static void Eat()
    {
        Debug.Log("吃东西!");
    }
}
#endregion



public class LuaCallCSharp : MonoBehaviour
{
    // private void Start() {
    //     Lesson4 lesson4 = new Lesson4();
    //     lesson4.Move();
        
    // }
}
