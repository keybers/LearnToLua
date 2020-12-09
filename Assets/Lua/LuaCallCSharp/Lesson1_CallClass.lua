print("**************toLua访问C#的类************")
--toLua和xLua访问C#类非常相似
--固定写法

--命名空间.类名
--unity的类 比如 GameObject Transform等 ————》 UnityEngine.类名

--通过C#中的类实例化一个对象 lua中没有new 所以我们直接使用 类名括号就是实例化对象
--省略CS.

local obj1 = UnityEngine.GameObject()
local obj2 = UnityEngine.GameObject("keyber")


--为了方便使用 节约性能 定义全局变更量来存储C#中的类
--相当于取一个别名

GameObject = UnityEngine.GameObject
local obj3 = GameObject("测试")

--类中的静态对象 都可以使用.来调用
local obj4 = GameObject.Find("keyber")

--得到对象中的成员变量 也是直接对象.属性即可
print(obj4.transform.position) -- 形式为表

--Debug 默认报错了 因为没有加入自定义设置文件中
--如果发现Lua使用C#中的类报错了 不认识 需要把它加入到CustomSetting文件中的CustomTypeList中去
--而后再通过菜单栏 生成Lua代码
Debug = UnityEngine.Debug
Debug.Log("你好 Debug")

--成员方法的使用
Vector3 = UnityEngine.Vector3
--要使用对象的成员方法一定要加：
obj4.transform:Translate(Vector3.right)
Debug.Log(obj4.transform.position.x)

--使用自定义继承了Mono的类
--继承的Mono的类 不能直接用
local obj5 = GameObject("加了脚本的类")
--通过GameObject的 AddComponent方法 添加脚本
--typeof 是tolua提供的一个得到type的方法
--自定义加的脚本不认识 也要加入
obj5:AddComponent(typeof(LuaCallCSharp))

--如果使用没有继承Mono的类
local t1 = Test()
t1:Speak("hello")

local t2 = MyTest.Test2()
t2:Speak("Fuck")
