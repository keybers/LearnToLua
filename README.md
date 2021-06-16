# LearnToLua

## **介绍**
初学习ToLua

## **热更底层实现原理**
### 介绍  
LuaInterface是Lua语言和Microsoft.NET平台公共语言运行时（SLR）之间的继承库。  
CLR(公共语言运行库)应用程序通过LuaInterface.Lua类来使用Lua解释器。实例化这个类，创建一个新的Lua解释器，不同实例之间直接完全独立，Lua类索引创建，读取和修改全部靠变量，由变量的名字索引。  
任何LuaInterface程序的第一个任务是加载所需的任何程序集，第二个任务是导入类型，在这种情况类是显示加载的，会调用他的静态方法。  LuaInterface将Lua类型的数据类型转换为.Net数据类型的等价物，它负责将 Lua 调用传递给底层 .NET 类。

 
### Lua类型对CSharp类型
nil <--> null  
numbers <--> Double  
booleans <--> Boolean  
tables <--> LuaInterface.LuaTable  
functions <-->LuaInterface.LuaTable  
Userdata是一种特殊情况：CLRobjects没有匹配的Lua类型，userdata转换回原类型当传递给CLR时，LuaInterface转换其它userdata到LuaInterface.LuaUserData.  
Lua类有RegisterFunction函数来注册CLR函数作为一个全局Lua函数，它的参数包含函数名字、目标函数和表示方法的方法信息。

### 常用Lua库简介
LuaInterface  
Lua 语言与 Microsoft .NET 平台的公共语言运行时 (CLR) 之间的集成。
  
LuaJSON  
Lua 的 JSON 解析器/编码器使用 LPEG 解析 JSON，以提高速度和灵活性。根据解析器/编码器选项，尽可能保留各种值。

MD5  
Lua的基本加密设施。

### 常见Lua问题
Lua实现三目运算符：a and {b} or {c},a不做运算，只是用来判断。
    
Lua删除表中元素：如果使用table.remove()的话，pos的位置根本不好找，因为Lua内部**非数组排序是根据hash值来的**，对于这种赋值为nil相当方便。  
for k,v in pairs(t) do  
   t[k] = nil  
end

table中的元素长度：  
local t = {1,2,3,4,nil,7}  
print(#t) --6  
local t = {1,5,2,3,nil}  
print(#t) --4 nil为最后一位的时候  
local t = {1,2,nil,nil,5}  
t[6] = 1  
print(#t)  --2 对于t[6]的插入也就是t[6]=1这一步，导致table表**rehash**，会产生夹断，#t就只有1，2两个元素的长度。  
Tip:table是有数组和node hash部分组成。