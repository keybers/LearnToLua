using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

public class Lesson1_LuaState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //主要学习目的 学习用toLua提供的解析器（虚拟机）对象执行lua代码和脚本

        //初始化一个 toLua解析器（虚拟机）
        LuaState luaState = new LuaState();
        //启动解析器
        luaState.Start();

        //执行Lua代码
        luaState.DoString("print('你好lua')");
        //执行lua代码 并指名出处 方便调试的时候查看
        luaState.DoString("print('你好,lua')","Lesson1_LuaState.cs");


        //执行Lua文件，可以跟后缀也可以不跟
        //luaState.DoFile("Main.lua");
        luaState.DoFile("Main");
        
        //第二种执行Lua文件的方法 这种方法不需要加后缀
        luaState.Require("Main");

        //检查解析器栈顶是否为空
        luaState.CheckTop();

        //销毁解析器
        luaState.Dispose();
        //最好制空
        luaState = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
