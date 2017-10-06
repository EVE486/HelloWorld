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
        public Stack car_old = new Stack();
        public Stack get = new Stack();              //get用于储存离开的车俩
        public void goOut()
        {
            var m0 = 0;
            Console.Write("请输入要退出车辆的号位： ");
            m0 = Convert.ToInt32(Console.ReadLine());
            if(m0<=n && m0>0)
            {
                for(int m1=0;m1<n+1-m0;m1++)   
                { 
                    if(m1!=n-m0)
                    {
                    car_old.Push(stop.Peek());
                    stop.Pop();
                    }
                    else
                    {
                      car0.checkTime2();
                      get.Push("离开的时间:"+car0.time2);
                      
                      stop.Pop();
                    }
                   
                }
                
            }
            else
            {
                Console.Write("您进行了操作违规或者停车场中并不存在该车，请重新输入：");
                goOut();
            }
            for(int m2=0;m2<n-m0;m2++)
            {
                stop.Push(car_old.Peek());
                car_old.Pop();
            }
            
            Console.WriteLine("退出成功\n" + "离开的时间为：" + car0.time2);
            n--;
            
        }

    }
}
