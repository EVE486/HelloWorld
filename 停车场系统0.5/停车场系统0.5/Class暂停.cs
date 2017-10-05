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
        public Stack car11 = new Stack();
        
        public void goOut()
        {
            var m0 = 0;
            Console.Write("请输入要退出车辆的号位： ");
            m0 = Convert.ToInt32(Console.ReadLine());

            if(m0<n && m0>0)
            {
                for(int m1=0;m1<nu+1-m0;m1++)   
                { 
                    if(m1!=nu-m0)
                    {
                    car0.position--;
                    car11.Push(stop.Peek());
                    stop.Pop();
                    }
                    else
                    stop.Pop();
                }
                
            }
            else
            {
                Console.Write("您进行的操作违规或者停车场中并不存在该车，请重新输入：");
                goOut();
            }

            car0.checkTime2();
            Console.WriteLine("退出成功\n"+"离开的时间为：" + car0.time2);
            n--;
            for(int m2=0;m2<nu-m0;m2++)
            {
                stop.Push(car11.Peek());
                car11.Pop();
            }
            nu--;
            
        }

    }
}
