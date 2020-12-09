using LuaInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson8_CallCoroutine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().LuaState.Require("Main");

        LuaFunction luaFunction = LuaManager.GetInstance().LuaState.GetFunction("startDelay");
        luaFunction.Call();
        luaFunction.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
