 --主入口函数。从这里开始lua逻辑
 function Main()					
 	print("logic start")	 		
 end

 --场景切换通知
 function OnLevelWasLoaded(level)
 	collectgarbage("collect")
 	Time.timeSinceLevelLoad = 0
 end

 function OnApplicationQuit()
 end

 --******************************************上面是默认脚本***********************

--print("**********第一个Lua脚本执行**********************")

--通过启动Main启动Test
--require("CSharpCallLua/Test")

--启动Lua调用的C#的逻辑脚本
--require("LuaCallCSharp/Lesson1_CallClass")
--require("LuaCallCSharp/Lesson2_Enum")
--require("LuaCallCSharp/Lesson3_CallArray")
--require("LuaCallCSharp/Lesson3_CallListDic")
--require("LuaCallCSharp/Lesson4_CallFunction")
--require("LuaCallCSharp/Lesson5_CallFunction")
--require("LuaCallCSharp/Lesson6_CallFunction")
--require("LuaCallCSharp/Lesson7_CallDelegateEvent")
--require("LuaCallCSharp/Lesson8_CallCoroutine")

