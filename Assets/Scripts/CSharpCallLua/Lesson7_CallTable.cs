using LuaInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson7_CallTable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //学会在C#中调用lua中的自定义Table
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().LuaState.Require("Main");

        LuaTable luaTable = LuaManager.GetInstance().LuaState.GetTable("testTable");
        //luaTable = LuaManager.GetInstance().LuaState["testTable"] as LuaTable; 这样也行

        //访问其中变量
        //中括号 变量名 就可以获取
        Debug.Log(luaTable["testInt"]);
        Debug.Log(luaTable["testBool"]);
        Debug.Log(luaTable["testString"]);
        Debug.Log(luaTable["testFloat"]);
        luaTable["testInt"] = 74;

        LuaTable luaTable1 = LuaManager.GetInstance().LuaState.GetTable("testTable");
        Debug.Log(luaTable["testInt"]);

        //表中函数
        LuaFunction luaFunction = luaTable1.GetLuaFunction("testFunction");
        luaFunction.Call();

        //表中表
    }
}
