using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace 停车场系统0._5
{
    class stackCar0:stackCar
    {
        public void charge(int n)
        {
            TimeSpan go1 = new TimeSpan(arrtime[n].Ticks);
            TimeSpan out1 = new TimeSpan(deptime.Ticks);
            TimeSpan span = go1.Subtract(out1).Duration();
            double money;
            money = span.Days * 45 + span.Hours * 2 + span.Minutes * 0.1;
            {

                    Console.WriteLine("------------------------------------------");
                    string diff = null;
                    diff = span.Days.ToString() + "天" + span.Hours + "小时" + span.Minutes + "分" + span.Seconds + "秒";
                    Console.WriteLine("停留的时间为" + span);
                    Console.WriteLine("缴纳的费用为：" + money+"元");
                    Console.WriteLine("------------------------------------------");
                
            }
        }
        public Stack car_old = new Stack();
        public void get(Stack car_old)         //get用于储存离开的车俩
        {
            ClassCar ovo = new ClassCar();
            ovo.checkTime2();
            car_old.Peek();
            
         }
        public void change(int changeN)  //当出站后，将后面车的时间往后移动
        {
           int m1 = 0;
           for(;m1<n-changeN;m1++)
           {
                   arrtime[changeN-1] = arrtime[changeN];
                                                         //注意此刻arrtime[n]值仍然存在
           }
        }

        public void goOut()
        {
            var m0 = 0;
            Console.Write("需要退出第几号车（从下往上数）： ");
            m0 = Convert.ToInt32(Console.ReadLine());
            var m00 = m0 - 1;
            if(m0<=n && m0>0)
            {
                for(int m1=0;m1<n+1-m0;m1++)       //将要退出车辆后面的车调到暂停栈里面
                { 
                    if(m1!=n-m0)
                    {
                    
                    car_old.Push(stop.Peek());
                    stop.Pop();
                    }
                    else
                    {
                      change(m0);
                      deptime = DateTime.Now;
                      Console.WriteLine("------------------------------------------");
                      Console.WriteLine("退出成功");
                      Console.WriteLine("车辆信息如下:");
                      Console.WriteLine(stop.Peek());
                      Console.WriteLine("车辆离开时间为：" + deptime);
                      charge(m00);
                      stop.Pop();
                    }
                   
                }
                
            }
            else
            {
                Console.Write("您进行了操作违规或者停车场中并不存在该车，请重新输入：");
                goOut();
            }
            for(int m2=0;m2<n-m0;m2++)     //将暂时停车栈里停留的车辆返回停车场，并且清空暂停栈
            {
                stop.Push(car_old.Peek());
                car_old.Pop();
            }
            
            n--;
            
        }


        public int changN { get; set; }
    }
}
