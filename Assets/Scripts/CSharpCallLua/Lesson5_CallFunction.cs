using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate int CustomDelegater(int a, out int b, out bool c, out string d, out int f);

public delegate int CustomDelegaterref(int a, ref int b, ref bool c, ref string d, ref int f);

public delegate void CustomCallParamsDelegater(int a, params object[] objs);//变长参数的最佳存储形式

public class Lesson5_CallFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().Require("Main");

        #region 无参数无返回
        //第一种方法 通过 GetFunction方法获取
        LuaFunction luaFunction = LuaManager.GetInstance().LuaState.GetFunction("testFunction");
        //调用
        luaFunction.Call();
        //执行完过后 销毁
        luaFunction.Dispose();

        //第二种方法通过中括号 函数名的形式
        luaFunction = LuaManager.GetInstance().LuaState["testFunction"] as LuaFunction;

        luaFunction.Call();

        luaFunction.Dispose();

        //第三种方式 转为委托来使用
        //首先得到一个luaFunction 而后再转为委托的形式
        luaFunction = LuaManager.GetInstance().LuaState["testFunction"] as LuaFunction;
        //通过luaFunction中的方法 存入到委托中使用
        UnityAction unityAction = luaFunction.ToDelegate<UnityAction>();

        unityAction();

        luaFunction.Dispose();
        #endregion

        #region 有参数有返回
        //第一种方式 通过LuaFunction的Call来访问
        LuaFunction luaFunction2 = LuaManager.GetInstance().LuaState.GetFunction("testFunction2");
        //开始使用
        luaFunction2.BeginPCall();
        //传参
        luaFunction2.Push(99);
        //传参结束 调用
        luaFunction2.PCall();
        //得到返回值
        int result = Convert.ToInt32(luaFunction2.CheckNumber());
        //执行结束
        luaFunction2.EndPCall();
        
        Debug.Log("有参数有返回：" + result);
        //第二种方式 通过luaFunction Invoke方法来调用
        //第一个参数是传参类型 最后一个泛型是返回值类型 前面的是参数类型 依次往后排

        result = luaFunction2.Invoke<int, int>(199);
        Debug.Log("有参数有返回 Invoke：" + result);

        //第三种方式 转委托
        Func<int, int> func = luaFunction2.ToDelegate<Func<int, int>>();
        result = func(900);
        Debug.Log("有参数有返回 delegate：" + result);

        //第四种方式 不得function 直接执行
        //参数依次传方法名 参数  最后true
        result = LuaManager.GetInstance().LuaState.Invoke<int, int>("testFunction2", 900, true);
        Debug.Log("有参数有返回 直接调用：" + result);


        luaFunction2.Dispose();
        #endregion

        #region 有参数多返回
        //第一种方式 call
        LuaFunction luaFunction3 = LuaManager.GetInstance().LuaState.GetFunction("testFunction3");
        luaFunction3.BeginPCall();
        luaFunction3.Push(78);
        luaFunction3.PCall();
        int a1 = Convert.ToInt32(luaFunction3.CheckNumber());
        int a2 = Convert.ToInt32(luaFunction3.CheckNumber());
        bool b1 = Convert.ToBoolean(luaFunction3.CheckBoolean());
        string s1 = Convert.ToString(luaFunction3.CheckString());
        int e1 = Convert.ToInt32(luaFunction3.CheckNumber());
        luaFunction3.EndPCall();

        Debug.Log("返回值：" + a1 + "_" + a2 + "_" + b1 + "_" + s1 + "_" + e1);

        //第二种方式 通过out来接
        //如果是自定义委托 来装Lua 必须做一件事
        //在关键文件 CustomSetting customDelegateList中去加自定义委托
        //而后在菜单中生成委托
        CustomDelegater customDelegater = luaFunction3.ToDelegate<CustomDelegater>();
        int b2;
        bool c2;
        string d2;
        int e2;
        result = customDelegater(78,out b2,out c2,out d2,out e2);
        Debug.Log("第二种返回值：" + result + "_" + b2 + "_" + c2 + "_" + d2 + "_" + e2);


        //第三种方式 通过ref来接
        CustomDelegaterref customDelegaterref = luaFunction3.ToDelegate<CustomDelegaterref>();
        int b3 = 0;
        bool c3 = false;
        string d3 = null;
        int e3 = 0;
        result = customDelegaterref(78, ref b3, ref c3, ref d3, ref e3);
        Debug.Log("第三种返回值：" + result + "_" + b2 + "_" + c2 + "_" + d2 + "_" + e2);
        luaFunction3.Dispose();

        #endregion

        #region 变长参数函数

        //第一种方式 通过自定义委托
        LuaFunction luaFunction4 = LuaManager.GetInstance().LuaState.GetFunction("testFunction4");
        CustomCallParamsDelegater customCallParamsDelegater = luaFunction4.ToDelegate<CustomCallParamsDelegater>();
        customCallParamsDelegater(78,"fs",false);

        //第二种方式 通过Call 无返回参数可以用 之前都有返回值就不用Call
        luaFunction4.Call<int, string, int, bool>(14, "sd", 56, false);

        #endregion

    }
}

