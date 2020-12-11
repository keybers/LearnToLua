print("**********toLua调用C#中重载函数*************")
local obj = Lesson6()


print(obj:Calc())
print(obj:Calc(1)) 
print(obj:Calc(1.0))
print(obj:Calc(1.2))
--toLua和XLua一样 对重载函数的精度支持不友好 参数1和1.2和1.0都是调用float类型参数
--lua中只有Number一种数值类型 分不清
print(obj:Calc("你好"))

--这里调用 是非out参数的重载
print(obj:Calc(10,1))
--在toLua中用out重载 有一个固定套路
--意味着使用 Unity中的一些API中有out时 我们就可以使用nil占位了
--toLua中对ref支持不太好 建议不要使用 特别是在重载函数的时候
print(obj:Calc(10,nil))

