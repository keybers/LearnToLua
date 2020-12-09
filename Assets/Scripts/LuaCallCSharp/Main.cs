using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    //作为C#的主入口来启动Lua脚本
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().LuaState.Require("Main");
    }
}
