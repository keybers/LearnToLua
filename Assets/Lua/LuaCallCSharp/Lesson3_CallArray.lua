print("***************toLua访问C#的数组***************")


local obj = Lesson3()

--数组的长度
print("数组的长度:" .. obj.array.Length)

--访问元素
print("访问元素：" .. obj.array[0])

--查找元素
print("查找元素：" .. obj.array:IndexOf(2))

--遍历 LUA中是以1开始 数组是以0开始

for i = 0 ,obj.array.Length - 1 do
    print("遍历元素：" .. obj.array[i])
end 

--toLua中比Xlua多了几种遍历方式
--迭代器遍历 使用的是

local item = obj.array:GetEnumerator()
while item:MoveNext() do
    print("item" .. item.Current)
end

--转table遍历
local t = obj.array:ToTable()
for i = 1, #t do
    print("table遍历:" .. t[i])
end

--创建数组 
--如果出现不认识的类 记得加入到配置文件
local array2 = System.Array.CreateInstance(typeof(System.Int32),10)
print(array2.Length)
array2[2] = 10
print(array2[2])