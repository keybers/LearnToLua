using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4_CallVariable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.GetInstance().Init();

        LuaManager.GetInstance().Require("Main");

        //获取全局变量
        //toLua中访问全局变量 一个套路 得到luaState解析器 然后中括号 变量名 即可得到
        Debug.Log("testNumber:" + LuaManager.GetInstance().LuaState["testNumber"]);
        Debug.Log("testBool:" + LuaManager.GetInstance().LuaState["testBool"]);
        Debug.Log("testString:" + LuaManager.GetInstance().LuaState["testString"]);
        Debug.Log("testFloat:" + LuaManager.GetInstance().LuaState["testFloat"]);

        //得到的是object,是值拷贝
        int value = Convert.ToInt32(LuaManager.GetInstance().LuaState["testNumber"]);
        value = 99;
        Debug.Log(LuaManager.GetInstance().LuaState["testNumber"]);
        
        //如果要改值 则直接改
        LuaManager.GetInstance().LuaState["testNumber"] = 99;
        Debug.Log(LuaManager.GetInstance().LuaState["testNumber"]);


        //获取本地变量
        //toLua中 没有办法通过C#得到Local申明的局部临时变量
        Debug.Log("testLocal:" + LuaManager.GetInstance().LuaState["testLocal"]);

        //可以在C#中添加全局变量 相当于在Lua中的_G中加一个变量
        LuaManager.GetInstance().LuaState["addValue"] = 178;
        Debug.Log(LuaManager.GetInstance().LuaState["addValue"]);
    }
}
