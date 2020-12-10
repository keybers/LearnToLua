print("**********************lua调用C#中的List Dic***********************")

--虽然自定义类Lesson3已经添加到CustomSettings中
--但是我们改变了这个类 里面添加了两个变量
--我们必须重新生成一次代码
local obj = Lesson3()
print("****List******")

obj.testList:Add(10)
obj.testList:Add(5)
obj.testList:Add(6)
obj.testList:Add(4)

print(obj.testList[0])

--长度
print("长度：" .. obj.testList.Count)

--遍历
for i = 0, obj.testList.Count - 1 do
    print("遍历:" .. obj.testList[i])
end

--在tolua中创建一个list
--缺点：toLua对泛型文件支持糟糕 想要用什么泛型类型的对象
--都需要在CustomSetting中去添加对应的类型 而后生成才能在ToLua中去使用
--List<String>
--这才是创建了string类型的list
local testList2 = System.Collections.Generic.List_string()
testList2:Add("jfk")
print(testList2[0])

print("**************Dic*****************")

obj.testDic:Add(1,"j")
obj.testDic:Add(2,"fd")
obj.testDic:Add(3,"sdsd")

print(obj.testDic[1])

--xlua是通过pairs遍历
--tolua中不支持遍历方式
--需要使用迭代器进行遍历

local item = obj.testDic:GetEnumerator()
while item:MoveNext() do
    local c = item.Current
    print("迭代器遍历：" .. c.Key .. "_".. c.Value)
end

local keyItem = obj.testDic.Keys:GetEnumerator()
while keyItem:MoveNext() do
    print("键：" .. keyItem.Current)
end

local keyItem = obj.testDic.Values:GetEnumerator()
while keyItem:MoveNext() do
    print("值：" .. keyItem.Current)
end

--如果在Lua中创建字典对象
--和List一样 需要在CustomSetting中去加字典类型

--Dictionary_键_值
local testDic2 = System.Collections.Generic.Dictionary_int_string()
testDic2:Add(1,"fsdfd")
print("创建的字典：" .. testDic2[1])

local testDic3 = System.Collections.Generic.Dictionary_int_string()
testDic3:Add("2",888)
--toLua使用字典中 不能直接通过字符串作为键来访问值
--print("创建的字典：" .. testDic2[1])
--用自带的方法获取 参数 值，键
local b,v = testDic3:TryGetValue("2",nil)
print(v)


