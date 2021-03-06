﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Lesson3Wrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Lesson3), typeof(System.Object));
		L.RegFunction("New", _CreateLesson3);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("array", get_array, set_array);
		L.RegVar("testList", get_testList, set_testList);
		L.RegVar("testDic", get_testDic, set_testDic);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLesson3(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				Lesson3 obj = new Lesson3();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Lesson3.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_array(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Lesson3 obj = (Lesson3)o;
			int[] ret = obj.array;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index array on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_testList(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Lesson3 obj = (Lesson3)o;
			System.Collections.Generic.List<int> ret = obj.testList;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index testList on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_testDic(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Lesson3 obj = (Lesson3)o;
			System.Collections.Generic.Dictionary<int,string> ret = obj.testDic;
			ToLua.PushSealed(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index testDic on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_array(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Lesson3 obj = (Lesson3)o;
			int[] arg0 = ToLua.CheckNumberArray<int>(L, 2);
			obj.array = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index array on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_testList(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Lesson3 obj = (Lesson3)o;
			System.Collections.Generic.List<int> arg0 = (System.Collections.Generic.List<int>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.List<int>));
			obj.testList = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index testList on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_testDic(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Lesson3 obj = (Lesson3)o;
			System.Collections.Generic.Dictionary<int,string> arg0 = (System.Collections.Generic.Dictionary<int,string>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.Dictionary<int,string>));
			obj.testDic = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index testDic on a nil value");
		}
	}
}

