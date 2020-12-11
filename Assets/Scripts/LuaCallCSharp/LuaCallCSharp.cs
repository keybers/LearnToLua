using System.Runtime.InteropServices;
using System.Net.Http.Headers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

#region  Lesson5_CallFunction

public class Lesson5
{
    public int RefFun(int a, ref int b,ref int c,int d)
    {
        b = a + d;
        c = a - d;
        return 100;
    }

    public int OutFun(int a, out int b,out int c, int d)
    {
        b = a;
        c = d;
        return 200;
    }

    public int RefOutFun(int a, out int b,ref int c)
    {
        b = a * 10;
        c = a * 20;
        return 300;
    }
}

#endregion

#region  Lesson6_CallFunction

public class Lesson6
{
    public int Calc()
    {
        return 100;
    }

    public int Calc(int a)
    {
        return a;
    }

    public float Calc(float a)
    {
        Debug.Log("Float");
        return a;
    }

    public string Calc(string a)
    {
        Debug.Log("string");
        return a;
    }

    public int Calc(int a,int b)
    {

        return a + b;
    }

    public int Calc(int a,out int b)
    {
        b = 10;
        return a + b;
    }
}

#endregion

#region  Lesson7_CallDelegateEvent

public class Lesson7
{
    public UnityAction unityAction;
    public event UnityAction eventAction;

    public void DoUnityAction()
    {
        if(unityAction != null)
        {
            unityAction();
        }
    }

    public void DoEvent()
    {
        if(eventAction != null)
        {
            eventAction();
        }
    }

    public void ClearEvent()
    {
        eventAction = null;
    }
}

#endregion


public class LuaCallCSharp : MonoBehaviour
{

}
