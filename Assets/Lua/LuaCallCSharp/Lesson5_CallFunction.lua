print("**************************toLua调用CSharp中的ref和out方法*************")

--toLua和Xlua中对ref和out函数的使用基本类似

--通过多返回值形式进行处理

--如果  是out和ref函数
--第一个返回值 是函数的默认返回值
--之后的返回值 就是ref 和 out对应的结果 从左到右 一一对应

local obj = Lesson5()
print(obj:RefFun(10,0,0,1))
local a,b,c = obj:RefFun(10,0,0,1)
print("a:" .. a)
print("b:" .. b)
print("c:" .. c)

--out 类型参数在toLua中不能省略 在XLua中可以省略
print(obj:OutFun(20,nil,nil,30)) --200 20 30
print(obj:OutFun(20,2,1,30))--200 20 30
local a1,b1,c1 = obj:OutFun(20,nil,nil,30)
print("a1:" .. a1)
print("b1:" .. b1)
print("c1:" .. c1)

print(obj:RefOutFun(20,nil,45))--300 200 400
local a2,b2,c2 = obj:RefOutFun(20,nil,45)
print("a2:" .. a1)
print("b2:" .. b1)
print("c2:" .. c1)

--在toLua中使用ref和out中 最好使用out